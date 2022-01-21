using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField]
    private GameObject endMenu;
    public TMP_Text winnerText;

    public Slider timeSlider;
    public Slider healthSlider;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
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
    public void ShowEndMenu()
    {
        endMenu.SetActive(true);
    }
    public void hideEndMenu()
    {
        GameManager.instance.RestartGame();
        endMenu.SetActive(false);
    }

    public void DisableMenus()
    {
        menu.SetActive(false);
    }

    public void UpdateTimeText(TMP_Text text)
    {
        text.text = timeSlider.value.ToString();
        GameManager.instance.roundTime = timeSlider.value;
    }

    public void UpdateHealthText(TMP_Text text)
    {
        text.text = healthSlider.value.ToString();
        GameManager.instance.startingHealth = (int)healthSlider.value;
    }

}
