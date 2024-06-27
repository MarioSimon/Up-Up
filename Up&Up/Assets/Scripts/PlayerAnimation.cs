using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator playerAnimator;
    private Rigidbody rb;

    [SerializeField] private float maxSpeed = 5f;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        playerAnimator.SetFloat("speed", rb.velocity.magnitude / maxSpeed);
    }
}
