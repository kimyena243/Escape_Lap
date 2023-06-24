using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    private float screenX = 3.0f;
    private float screenY = 5.0f;
    private GameObject target;
    [SerializeField]private float speed = 5f; // 이동 속도
    
    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        if (target == null)
        {
            Destroy(gameObject); // 유도 대상이 없으면 유도탄 파괴
            return;
        }

        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);

        // 총알의 현재 위치
        Vector3 currentPosition = transform.position;

        // 화면 밖으로 벗어난 경우 총알 제거
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
