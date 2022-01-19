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
    [SerializeField]
    private GameObject planeMenu;
    [SerializeField]
    private GameObject mapMenu;
    [SerializeField]
    private GameObject planeMenuPlayer2;


    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
    public void PlaneMenu()
    {
        planeMenu.SetActive(true);
    }
    public void PlaneMenuPlayer2()
    {
        planeMenuPlayer2.SetActive(true);
    }
    public void MapMenu()
    {
        mapMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void DisableMenus()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        Instantiate(gameManager.plane1);
        Instantiate(gameManager.plane2);

        menu.SetActive(false);
    }
}
