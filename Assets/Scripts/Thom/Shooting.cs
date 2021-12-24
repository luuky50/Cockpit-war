using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPreFab;

    public float bulletForce;
    public float fireSpeed;
    public float canFire;

    public AudioClip shootClip;

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

        GameObject bullet2 = Instantiate(bulletPreFab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rigidbody2D2 = bullet2.GetComponent<Rigidbody2D>();
        rigidbody2D2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);

        
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(shootClip, 0.1f);

    }
}

