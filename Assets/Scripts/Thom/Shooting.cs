using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;

    public float bulletForce = 25f;
    public float fireSpeed = 0.15f;
    public float canFire = 1f;
    

    // Update is called once per frame
    void Update()
    {
        PlaneInfo planeInfo = GetComponent<PlaneInfo>();
        if (!planeInfo.isPlayer2 && Input.GetKey(KeyCode.W) && Time.time > canFire)
        {
            Shoot();
            canFire = Time.time + fireSpeed;
        } else if (planeInfo.isPlayer2 && Input.GetKey(KeyCode.UpArrow) && Time.time > canFire)
        {
            Shoot();
            canFire = Time.time + fireSpeed;
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
       
    }
}

