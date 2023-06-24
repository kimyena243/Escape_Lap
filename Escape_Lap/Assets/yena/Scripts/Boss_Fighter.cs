using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Fighter : Basic_Fighter
{
    [SerializeField] private float HomingSpeed;
    [SerializeField] private float LazerSpeed;
    [SerializeField] private GameObject HomingMissileBullet;
    [SerializeField] private GameObject[] SpawnFighter;
    [SerializeField] private float randomTime;
    private int stunRandom;
    private Vector3[] pos;
    private Quaternion[] rot;

    private BossState currentState;
    enum BossState
    {
        Attack,
        Rush,
        Spawn,
        HomingMissile

    }
    public override void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        SetState(BossState.Spawn);
        StartCoroutine(StunSpawn());
    }
    IEnumerator StunSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(randomTime);

            stunRandom = Random.Range(0, 2);

            if (stunRandom == 0)
            {
                //float x = Random.Range(-2.5f, 2.5f);
                Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), -5.0f, 0f);
                Instantiate(SpawnFighter[stunRandom], pos, Quaternion.identity);

            }
            if (stunRandom == 1)
            {

                Vector3 pos = new Vector3(0f, -5.0f, 0f);
                Instantiate(SpawnFighter[stunRandom], pos, Quaternion.identity);
            }
        }
    }
   
    private void SetState(BossState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case BossState.Attack:
                AttackPattern();
                break;
            case BossState.Rush:
                RushPattern();
                break;
            case BossState.Spawn:
                SpawnPattern();
                break;
            case BossState.HomingMissile:
                HomingMissilePattern();
                break;

        }
    }
    private void AttackPattern()
    {
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject bulletObject1 = Instantiate(Bullet, new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z),Quaternion.identity);
            bulletObject1.GetComponent<Bullet>().Move();
            GameObject bulletObject2 = Instantiate(Bullet, transform.position, Quaternion.identity);
            bulletObject2.GetComponent<Bullet>().Move();
            GameObject bulletObject3 = Instantiate(Bullet, new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z), Quaternion.identity);
            bulletObject3.GetComponent<Bullet>().Move();

            yield return new WaitForSeconds(BulletSpeed);
        }
    }
    private void RushPattern()
    {
        rd.AddForce(Vector2.down * Speed);
    }
    private void SpawnPattern()
    {
        StartCoroutine(Spawn());

    }
    IEnumerator Spawn()
    {
        while (true)
        {
            pos = new Vector3[4];
            rot = new Quaternion[4];

            pos[0] = new Vector3(-2.5f, 5.0f, 0f); // 왼쪽위
            rot[0] = Quaternion.Euler(0f, 0f, 208f);
            pos[1] = new Vector3(2.5f, 5.0f, 0f); //오른쪽 위
            rot[1] = Quaternion.Euler(0f, 0f, 152f);
            pos[2] = new Vector3(-2.5f, -5.0f, 0f);//왼쪽 아래
            rot[2] = Quaternion.Euler(0f, 0f, -28f);
            pos[3] = new Vector3(2.5f, -5.0f, 0f); // 오른쪽 아래
            rot[3] = Quaternion.Euler(0f, 0f, 28f);


            int ran = Random.Range(0, 4);

            Instantiate(SpawnFighter[2], pos[ran], rot[ran]);

            yield return new WaitForSeconds(LazerSpeed);
        }
    }
    private void HomingMissilePattern()
    {
        StartCoroutine(HomingMissile());
    }
    IEnumerator HomingMissile()
    {
        while (true)
        {
            Instantiate(HomingMissileBullet,transform.position, Quaternion.identity);
            yield return new WaitForSeconds(HomingSpeed);
        }
    }


}
