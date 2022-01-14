using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHealthManagement : MonoBehaviour
{
    Puntentelling puntentelling;
    public int health;
    [SerializeField]
    private int currentHealth;
    public Transform respawnPoint;

    void Start()
    {
        currentHealth = health;
        puntentelling = GetComponent<Puntentelling>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth<=0)
        {
            //Destroy(gameObject);
            currentHealth = 10;
            gameObject.transform.position = respawnPoint.transform.position;
            puntentelling.AddPoint();
        }
    }

    public void TakeDamage(int damage)
    {
        PlaneController planeController = GetComponent<PlaneController>();
        if (!planeController.shield.activeSelf)
        {
            currentHealth -= damage;
        }
        else
        {
            planeController.shield.SetActive(false);
        }
    }
}
