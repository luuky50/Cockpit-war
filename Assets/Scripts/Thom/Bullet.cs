using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5;

    public int damageToGive;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Puntentelling>().HurtEnemy(damageToGive);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
