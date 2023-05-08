using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    [SerializeField] Pendulum pendulum;
    public float pushForce = 50f;
    public bool axisX;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb == null) { return; }

        if (axisX)
        {
            if (pendulum.transform.rotation.x < -0f)
            {
                rb.AddForce(Vector3.back * pushForce, ForceMode.Impulse);
            }
            else if (pendulum.transform.rotation.x > 0f)
            {
                rb.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);
            }
        }
        else
        {
            if (pendulum.transform.rotation.z < -0f)
            {
                rb.AddForce(Vector3.right * pushForce, ForceMode.Impulse);
            }
            else if (pendulum.transform.rotation.z > 0f)
            {
                rb.AddForce(Vector3.left * pushForce, ForceMode.Impulse);
            }
        }

    }
}
