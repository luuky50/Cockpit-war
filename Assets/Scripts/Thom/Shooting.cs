using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;

    public float bulletForce = 30f;
    

    // Update is called once per frame
    void Update()
    {
        PlaneInfo planeInfo = GetComponent<PlaneInfo>();
        if (!planeInfo.isPlayer2 && Input.GetKeyDown(KeyCode.W)) {
            Shoot();
        } else if (planeInfo.isPlayer2 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Shoot();
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
       
    }
}

