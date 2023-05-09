using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunableWall : MonoBehaviour
{

    private Vector3 worldGravity;

    private void Start()
    {
        worldGravity = Physics.gravity;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent.tag == "Player")
        {
            //other.GetComponent<Rigidbody>().useGravity = false; 
            Physics.gravity = Physics.gravity / 4;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent.tag == "Player")
        {
            //other.GetComponent<Rigidbody>().useGravity = true;
            Physics.gravity = worldGravity;
        }
    }
}
