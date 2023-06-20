using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rd;
    public float Speed;

    public void Move()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        rd.AddForce(Vector2.down * Speed);
    }

    public void CircleMove(Vector3 direction, float speed)
    {
        rd = GetComponent<Rigidbody2D>();
        rd.AddForce(direction * speed, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Delete"))
        {
            Destroy(this.gameObject);
           

        }

    



    }
}
