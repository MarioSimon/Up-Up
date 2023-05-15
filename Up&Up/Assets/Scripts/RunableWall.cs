using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunableWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            other.GetComponent<PlayerController>().playerState = PlayerState.WallRunning;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().playerState = PlayerState.Jumping;
        }
    }
}
