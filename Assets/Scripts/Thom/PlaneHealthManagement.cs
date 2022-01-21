using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaneHealthManagement : MonoBehaviour
{
    Puntentelling puntentelling;
    public int health;
    [SerializeField]
    private int currentHealth;
    public Slider healthSlider;
    public TMP_Text playerNumber;
    public Transform respawnPoint;
    public GameObject explosionPreFab;
    bool hasDied = false;

    void Start()
    {
        currentHealth = health;
        puntentelling = FindObjectOfType<Puntentelling>();
        healthSlider.maxValue = health;
    }

    public void Death()
    {
        hasDied = true;
        PlaneInfo planeInfo = GetComponent<PlaneInfo>();
        puntentelling.AddPoint(!planeInfo.isPlayer2);
        print("Respawn: " + gameObject.name);
        GameManager.instance.Respawn(playerNumber.text, gameObject);
    }


    public void TakeDamage(int damage)
    {
        PlaneController planeController = GetComponent<PlaneController>();
        if (!planeController.shield.activeSelf)
        {
            currentHealth -= damage;
            if (currentHealth <= 0 && !hasDied)
            {
                Instantiate(explosionPreFab, transform.position, transform.rotation);
                Death();
            }
            UpdateHealthSlider(damage);

        }
        else
        {
            planeController.shield.SetActive(false);
        }
    }

    public void UpdateHealthSlider(int damage)
    {
        healthSlider.value += damage;
    }
}
