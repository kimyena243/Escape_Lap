using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float scrollRange;
    public Vector3 dir = Vector3.down;

    void Start()
    {

    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
        if (transform.position.y < -scrollRange)
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }
    }
}
