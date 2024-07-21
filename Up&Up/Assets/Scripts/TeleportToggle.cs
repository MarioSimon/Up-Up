using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportToggle : MonoBehaviour
{
    [SerializeField] GameObject window;
    [SerializeField] Button yesBtn;
    [SerializeField] Button noBtn;
    void Start()
    {
        yesBtn.onClick.AddListener(CloseWindow);
        noBtn.onClick.AddListener(DeactivateTeleports);
    }

    private void DeactivateTeleports()
    {
        Teleporter[] teleporters = FindObjectsOfType<Teleporter>();

        foreach (Teleporter tp in teleporters) {
            tp.gameObject.SetActive(false);
        }

        CloseWindow();
    }

    private void CloseWindow()
    {
        window.SetActive(false);
    }
}
