using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public enum Power
    {
        Speed,
        RapidFire,
        Shield,
        Turning
    }

    public Power power;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Colliding with: " + collision);
        if (collision.gameObject.tag == "Player")
        {


            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //if(power)
    }
    // Update is call1ed once per frame
    void Update()
    {
        
    }
}