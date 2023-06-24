using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rd;
    public float Speed;
    private float screenX = 3.0f; 
    private float screenY = 5.0f; 
    public void Move()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        rd.AddForce(Vector2.down * Speed);
    }
    private void Update() //화면 벗어나면 사라지게
    {
        // 총알의 현재 위치
        Vector3 currentPosition = transform.position;

        // 화면 밖으로 벗어난 경우 총알 제거
        if (currentPosition.x < -screenX || currentPosition.x > screenX ||
            currentPosition.y < -screenY || currentPosition.y > screenY)
        {
            Destroy(this.gameObject);
        }
    }
    public void CircleMove(Vector3 direction, float speed)
    {
        rd = GetComponent<Rigidbody2D>();
        rd.AddForce(direction * speed, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
           

        }
    }
}
