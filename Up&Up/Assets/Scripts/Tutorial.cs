using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialPanel;

    private void OnTriggerEnter(Collider other)
    {
        tutorialPanel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        tutorialPanel.SetActive(false);
    }
}
