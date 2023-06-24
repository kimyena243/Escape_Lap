using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    private float screenX = 3.0f;
    private float screenY = 5.0f;
    private GameObject target;
    [SerializeField]private float speed = 5f; // �̵� �ӵ�
    
    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        if (target == null)
        {
            Destroy(gameObject); // ���� ����� ������ ����ź �ı�
            return;
        }

        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);

        // �Ѿ��� ���� ��ġ
        Vector3 currentPosition = transform.position;

        // ȭ�� ������ ��� ��� �Ѿ� ����
        if (currentPosition.x < -screenX || currentPosition.x > screenX ||
            currentPosition.y < -screenY || currentPosition.y > screenY)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);


        }
    }
}
