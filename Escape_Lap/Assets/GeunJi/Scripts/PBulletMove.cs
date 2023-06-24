using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBulletMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Vector2 dir = Vector2.up;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (transform.position.y > 5.3f)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (GameManager.Playing)
            rb.MovePosition(rb.position + speed * dir * Time.deltaTime);
    }
}
