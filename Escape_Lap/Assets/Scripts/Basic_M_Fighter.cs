using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_M_Fighter : Basic_Fighter
{
    [SerializeField] private int numberOfBullets;
    [SerializeField] private float bulletSpeed; // �Ѿ� �ӵ�

  
    public override void ShootStart() // �⺻ ���� 
    {
        StartCoroutine(Shoot());


    }
    IEnumerator Shoot()
    {
      
        while (true)
        {

            float angleStep = 360f / numberOfBullets; // �Ѿ� ������ ���� ����

            for (int i = 0; i < numberOfBullets; i++)
            {
                float angle = i * angleStep; // ���� �Ѿ��� ����
                Vector3 spawnPosition = transform.position - new Vector3(0, 1f, 0); // �Ѿ��� ���� ��ġ

                // ������ ���� �Ѿ��� ���� ���� ���
                Vector3 bulletDirection = Quaternion.Euler(0, 0, angle) * Vector3.up;

                // �Ѿ� ����
                GameObject bullet = Instantiate(Bullet, spawnPosition, Quaternion.identity);
                bullet.transform.SetParent(transform); // ���� ������Ʈ�� �ڽ����� ����
                bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Scale ���� (1, 1, 1)�� ����
                //bullet.transform.localScale = Vector3.one; // Scale ���� (1, 1, 1)�� ����
                bullet.GetComponent<Bullet>().CircleMove(bulletDirection, bulletSpeed);
            }

            yield return new WaitForSeconds(BulletSpeed);
        }
    }




}
