using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Puntentelling : MonoBehaviour
{
    public int player;
    public int health;
    [SerializeField]
    private int currentHealth;
    public Transform respawnPoint;
    [SerializeField]
    private int puntenPlane;

    [SerializeField]
    private Text text;

    void Start()
    {
        currentHealth = health;
        puntenPlane = 0;
       
    }

    // Update is called once per frame
    void Update()
        
    {

        if (currentHealth <= 0)
        {
            //Destroy(gameObject);
            currentHealth = 10;
            gameObject.transform.position = respawnPoint.transform.position;
            puntenPlane++;
            text.text = "Player" + player + ": "+ puntenPlane.ToString();
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
