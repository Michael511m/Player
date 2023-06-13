using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 15f;
    int damage = 1;

   


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 1f);
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hp hp = collision.gameObject.GetComponent<Hp>();
        if(hp != null)
        {
            hp.TakeDamage(damage);
        }
        
        Destroy(gameObject);
       
        
        
        
    }

}
