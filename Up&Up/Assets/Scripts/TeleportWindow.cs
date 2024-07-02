using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportWindow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<Button> buttons;
    [SerializeField] Button closeWindow;

    [SerializeField] GameObject blocker;
    [SerializeField] List<GameObject> blockers;

    [SerializeField] List<Transform> teleportPositions;
    private void Start()
    {
        // for (int i = 0; i < buttons.Count; i++)
        // {
        //     buttons[i].onClick.AddListener(delegate { Teleport(i); });
        // }
        buttons[0].onClick.AddListener(delegate { Teleport(0); });
        buttons[1].onClick.AddListener(delegate { Teleport(1); });
        buttons[2].onClick.AddListener(delegate { Teleport(2); });
        buttons[3].onClick.AddListener(delegate { Teleport(3); });
        buttons[4].onClick.AddListener(delegate { Teleport(4); });
        buttons[5].onClick.AddListener(delegate { Teleport(5); });
        buttons[6].onClick.AddListener(delegate { Teleport(6); });
        buttons[7].onClick.AddListener(delegate { Teleport(7); });
        buttons[8].onClick.AddListener(delegate { Teleport(8); });
        buttons[9].onClick.AddListener(delegate { Teleport(9); });


        closeWindow.onClick.AddListener(CloseWindow);
    }

    private void Teleport(int positionID)
    {
        player.transform.position = teleportPositions[positionID].position;
    }

    private void CloseWindow()
    {
        EnableBlockers();
        this.gameObject.SetActive(false);
    }

    public void ActivateTeleportPoint(int levelID)
    {
        blockers[levelID].SetActive(false);
    }

    public void DisableBlockers()
    {
        blocker.SetActive(false);
    }

    public void EnableBlockers()
    {
        blocker.SetActive(true);
    }
}
