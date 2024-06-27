using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction movement;
    private InputAction look;

    [SerializeField] private float movementForce;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;

    public PlayerState playerState = PlayerState.Grounded;

    private Rigidbody rb;
    private Animator playerAnimator;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField] private Transform followTarget;
    [SerializeField] private Camera playerCamera;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        
    }

    private void OnEnable()
    {
        movement = playerInput.Player.Move;
        movement.Enable();

        playerInput.Player.Jump.performed += DoJump;
        playerInput.Player.Jump.Enable();

        look = playerInput.Player.Look;
        look.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        playerInput.Player.Jump.Disable();
        look.Disable();
    }

    private void Update()
    {
        followTarget.rotation *= Quaternion.AngleAxis(look.ReadValue<Vector2>().x * rotationSpeed, Vector3.up);
        followTarget.rotation *= Quaternion.AngleAxis(look.ReadValue<Vector2>().y * rotationSpeed, Vector3.right);

        var angles = followTarget.localEulerAngles;
        angles.z = 0;

        var angle = followTarget.localEulerAngles.x;
        if (angle > 180 && angle < 320)
        {
            angles.x = 320;
        }
        else if (angle < 180 && angle > 60)
        {
            angles.x = 60;
        }

        followTarget.localEulerAngles = angles;

        followTarget.position = transform.position;
        followTarget.position += Vector3.up * 1.5f;
    }

    private void FixedUpdate()
    {
        forceDirection += movement.ReadValue<Vector2>().x * movementForce * GetCameraRight(playerCamera);
        forceDirection += movement.ReadValue<Vector2>().y * movementForce * GetCameraForward(playerCamera);

        rb.AddForce(forceDirection, ForceMode.VelocityChange);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0)
        {
            if (playerState != PlayerState.WallRunning)
            {
                rb.AddForce(Physics.gravity * rb.mass * 7.5f);
            }            
            else 
            {
                rb.AddForce(Physics.gravity * rb.mass / 4f);
            }
        }

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;

        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        }

        LookAt();
    }

    private void LateUpdate()
    {
        if (playerState != PlayerState.Grounded)
          IsGrounded();
    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0;

        if (movement.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            rb.rotation = Quaternion.LookRotation(direction, Vector3.up);          
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;

        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;

        return right.normalized;
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (playerState == PlayerState.Jumping) { return; }
        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("jump");
        }
        
        playerState = PlayerState.Jumping;
        rb.velocity = rb.velocity + Vector3.up * 0.1f;
        forceDirection += Vector3.up * jumpForce;
        
    }

    public void IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        
        if (/*Physics.Raycast(ray, out RaycastHit hit, 1.3f) &&*/ rb.velocity.y == 0) //cuando el origen este en 0 0 0 bajar a 0.3
        {
            playerState = PlayerState.Grounded;
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("grounded");
            }
            
        }
    }     
}

public enum PlayerState
{
    Grounded = 0,
    Jumping = 1,
    WallRunning = 2
}