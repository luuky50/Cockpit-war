using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Power
{
    Speed,
    RapidFire,
    Shield,
    Turning
}

public class PowerUp : MonoBehaviour
{
    public Sprite[] sprite;
    public Power power;
    [SerializeField]
    private int expireTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Colliding with: " + collision);
        if (collision.gameObject.tag == "Player")
        {
            PlaneController planeController = collision.GetComponent<PlaneController>();
            planeController.ReceivePower(power, expireTime);
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        int randomValue = Random.Range(0, 4);
        power = (Power)randomValue;
        GetComponent<SpriteRenderer>().sprite = sprite[randomValue];
    }

    // Update is call1ed once per frame
    void Update()
    {
        
    }
}
