using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector3[] move = new Vector3[4] { Vector3.up, Vector3.down, Vector3.left, Vector3.right };
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
        Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);

        if (transform.position.y < 4.3f)
            if (Input.GetKey(KeyCode.W))
                pos = move[0] * speed;
        if (transform.position.x > -2.3f)
            if (Input.GetKey(KeyCode.A))
                pos = move[2] * speed;
        if (transform.position.y > -4.3f)
            if (Input.GetKey(KeyCode.S))
                pos = move[1] * speed;
        if (transform.position.x < 2.3f)
            if (Input.GetKey(KeyCode.D))
                pos = move[3] * speed;

        transform.position += pos;
    }
}
