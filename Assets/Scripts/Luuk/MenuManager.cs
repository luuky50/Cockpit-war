using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject settingsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("Thom");
    }

    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
