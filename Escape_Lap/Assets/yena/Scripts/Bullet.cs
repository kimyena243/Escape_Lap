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
    private void Update() //ȭ�� ����� �������
    {
        // �Ѿ��� ���� ��ġ
        Vector3 currentPosition = transform.position;

        // ȭ�� ������ ��� ��� �Ѿ� ����
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
