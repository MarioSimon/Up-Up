using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunableWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent.tag == "Player")
        {
            other.GetComponent<Rigidbody>().useGravity = false; 
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent.tag == "Player")
        {
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
