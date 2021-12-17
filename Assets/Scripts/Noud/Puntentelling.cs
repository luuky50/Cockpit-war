using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puntentelling : MonoBehaviour
{
    
    public int health;
    [SerializeField]
    private int currentHealth;
    public Transform respawnPoint;
    private int puntenPlane;

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
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
