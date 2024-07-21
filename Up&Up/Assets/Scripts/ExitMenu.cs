using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    [SerializeField] GameObject exitWindow;
    [SerializeField] Button exitButton;
    [SerializeField] Button backButton;

    void Start()
    {
        exitButton.onClick.AddListener(CloseGame);
        backButton.onClick.AddListener(ToggleExitWindow);
    }

    private void CloseGame()
    {
        Application.Quit();
    }

    public void ToggleExitWindow()
    {
        bool toggle = !exitWindow.activeInHierarchy;
        exitWindow.SetActive(toggle);
    }

}
