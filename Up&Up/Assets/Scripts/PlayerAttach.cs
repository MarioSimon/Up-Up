using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent.tag == "Player")
        {
            parent.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Transform parent = other.transform.parent;

        if (parent.tag == "Player")
        {
            parent.parent = null;
        }
    }
}
