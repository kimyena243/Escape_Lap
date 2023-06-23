using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_M_Fighter : Basic_Fighter
{
    [SerializeField] private int numberOfBullets;
    [SerializeField] private float bulletSpeed; // 총알 속도

  
    public override void ShootStart() // 기본 공격 
    {
        StartCoroutine(Shoot());


    }
    IEnumerator Shoot()
    {
      
        while (true)
        {

            float angleStep = 360f / numberOfBullets; // 총알 사이의 각도 간격

            for (int i = 0; i < numberOfBullets; i++)
            {
                float angle = i * angleStep; // 현재 총알의 각도
                Vector3 spawnPosition = transform.position - new Vector3(0, 1f, 0); // 총알의 생성 위치

                // 각도에 따른 총알의 방향 벡터 계산
                Vector3 bulletDirection = Quaternion.Euler(0, 0, angle) * Vector3.up;

                // 총알 생성
                GameObject bullet = Instantiate(Bullet, spawnPosition, Quaternion.identity);
                bullet.transform.SetParent(transform); // 스폰 오브젝트의 자식으로 설정
                bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Scale 값을 (1, 1, 1)로 설정
                //bullet.transform.localScale = Vector3.one; // Scale 값을 (1, 1, 1)로 설정
                bullet.GetComponent<Bullet>().CircleMove(bulletDirection, bulletSpeed);
            }

            yield return new WaitForSeconds(BulletSpeed);
        }
    }




}
