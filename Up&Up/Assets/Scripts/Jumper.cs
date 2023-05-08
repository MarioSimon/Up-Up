using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] float jumpForce = 100f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        Animator animator = other.gameObject.GetComponent<Animator>();

        if (pc != null)
        {
            //animator.SetTrigger("jump");
            Vector3 newForce = rb.velocity;
            newForce.y = jumpForce;

            rb.velocity = newForce;
        }     
    }
}
