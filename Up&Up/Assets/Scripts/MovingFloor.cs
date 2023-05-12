using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    public float movementSpeedX = 5;
    public float movementSpeedZ = 5;

    GameObject player;

    void Update()
    {
        if (player != null)
        {
            float newX = movementSpeedX * Time.deltaTime;
            float newZ = movementSpeedZ * Time.deltaTime;

            Vector3 displacement = new Vector3(newX, 0, newZ);

            player.transform.position += displacement;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = null;
        }
    }
}
