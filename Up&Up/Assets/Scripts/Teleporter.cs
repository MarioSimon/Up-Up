using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] int levelID;
    [SerializeField] GameObject message;
    [SerializeField] GameObject teleportWindow;

    bool isPlayerNearby;

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {            
                teleportWindow.GetComponent<TeleportWindow>().DisableBlockers();
            }

            message.SetActive(false);
            teleportWindow.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerNearby = true;
        }

        teleportWindow.GetComponent<TeleportWindow>().ActivateTeleportPoint(levelID);
        message.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerNearby = false;
        }

        if (message.activeInHierarchy)
        {
            message.SetActive(false);
        }

        if (teleportWindow.activeInHierarchy)
        {
            teleportWindow.SetActive(false);
            teleportWindow.GetComponent<TeleportWindow>().EnableBlockers();
        }
    }
}
