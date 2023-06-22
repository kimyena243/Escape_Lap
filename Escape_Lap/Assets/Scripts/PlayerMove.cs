using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector3 Up = Vector3.up;
    public Vector3 Dowm = Vector3.down;
    public Vector3 Left = Vector3.left;
    public Vector3 Right = Vector3.right;
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Playing)
            Move();
    }

    private void Move()
    {
        if (transform.position.y < 4.3f)
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Up * speed;
            }
        if (transform.position.x > -2.3f)
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Left * speed;
            }
        if (transform.position.y > -4.3f)
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Dowm * speed;
            }
        if (transform.position.x < 2.3f)
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Right * speed;
            }
    }
}
