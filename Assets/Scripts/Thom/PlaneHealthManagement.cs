using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHealthManagement : MonoBehaviour
{
    public int health;
    [SerializeField]
    private int currentHealth;
    public Transform respawnPoint;

    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth<=0)
        {
            //Destroy(gameObject);
            currentHealth = 10;
            gameObject.transform.position = respawnPoint.transform.position;
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
