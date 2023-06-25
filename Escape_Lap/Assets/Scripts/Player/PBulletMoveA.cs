using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBulletMoveA : MonoBehaviour
{
    private GameObject target;
    public Rigidbody2D rb;
    public float speed;
    public Vector2 dir = Vector2.up;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y > 5.3f)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (GameManager.Playing)
            rb.MovePosition(rb.position + speed * dir * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
