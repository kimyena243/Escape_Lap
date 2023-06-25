using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float scrollRange;
    public Vector3 dir = Vector3.down;

    public static float GoalCount;

    void Start()
    {
        GoalCount = 0.0f;
    }

    void Update()
    {
        if (GameManager.Playing)
        {
            mapMove();
            GoalCount += 0.001f;
        }
    }

    private void mapMove()
    {
        transform.position += dir * speed * Time.deltaTime;
        if (transform.position.y < -scrollRange)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z) + Vector3.up * scrollRange;
        }
    }
}
