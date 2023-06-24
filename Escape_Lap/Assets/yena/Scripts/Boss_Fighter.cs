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
    private int randomNum;
    [SerializeField] private float stateChange;
    private GameObject[] parts;
    private int currentChildIndex = 0;
    private BossState currentState;
    [SerializeField] private bool isRush = false;
    [SerializeField] private bool isRushStop = false;
    [SerializeField] private float dashSpeed;
    enum BossState
    {
        Idle,
        Attack,
        Rush,
        Spawn,
        HomingMissile

    }
    IEnumerator RandomState()
    {
        
        while (true)
        {
            randomNum = Random.Range(1, 11);

            Debug.Log(randomNum);
            if (randomNum >= 1 && randomNum <= 4)
            { 
                SetState(BossState.Attack); 
            }
            else if (randomNum >= 5 && randomNum <= 7)
            {
                SetState(BossState.HomingMissile);
            }
            else if (randomNum == 8 || randomNum == 9)
            {
                SetState(BossState.Spawn);
            }
            else if (randomNum == 10)
            {
                SetState(BossState.Rush );
            }
          

            yield return new WaitForSeconds(stateChange);
            

        }

    }
    public override void Start()
    {
        parts = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            parts[i] = transform.GetChild(i).gameObject;
        }

        EnableCurrentChildCollider();

        rd = gameObject.GetComponent<Rigidbody2D>();
    
        StartCoroutine(RandomState());
        StartCoroutine(StunSpawn());
    }
    public override void Update()
    {
        if (parts[currentChildIndex].activeSelf == false)
        {
            // 현재 자식 오브젝트의 콜라이더 비활성화
            parts[currentChildIndex].GetComponent<PolygonCollider2D>().enabled = false;

            // 다음 자식 오브젝트로 이동
            currentChildIndex = (currentChildIndex + 1) % parts.Length;

            EnableCurrentChildCollider();
        }


        if( isRush == true)
        {
            transform.Translate(Vector3.down * dashSpeed * Time.deltaTime);
        }
        if (isRushStop == true)
        {
            if (transform.position.y <= 2.0f)
            {
                transform.Translate(Vector3.up * dashSpeed * Time.deltaTime);
            }
        }
    }
    IEnumerator BoolRushStop()
    {
        yield return new WaitForSeconds(2f);
        isRushStop = false;

    }
    private void EnableCurrentChildCollider()
    {
        // 현재 자식 오브젝트의 콜라이더 활성화
        parts[currentChildIndex].GetComponent<PolygonCollider2D>().enabled = true;
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
            case BossState.Idle:
                break;
            case BossState.Attack://4
                AttackPattern();
                break;
            case BossState.Rush://1
                RushPattern();
                break;
            case BossState.Spawn://2
                SpawnPattern();
                break;
            case BossState.HomingMissile://3
                HomingMissilePattern();
                break;

        }
    }
    private void AttackPattern()
    {
        StartCoroutine("Shoot");
        StartCoroutine("Stop");
       
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
  
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(stateChange);

        StopCoroutine("Shoot");
        StopCoroutine("Spawn");
        StopCoroutine("HomingMissile");
    }
    private void RushPattern()
    {
        parts[4].SetActive(true);
        
        StartCoroutine("Rush");
    }
    IEnumerator Rush()
    {
        yield return new WaitForSeconds(2f);
        isRush = true;
        parts[5].SetActive(true);
        StartCoroutine("RushStop");
    }
    IEnumerator RushStop()
    {
        yield return new WaitForSeconds(2f);
        isRush = false;
        isRushStop = true;
        parts[4].SetActive(false);
        parts[5].SetActive(false);
        StartCoroutine("BoolRushStop");
    }

    private void SpawnPattern()
    {
        StartCoroutine("Spawn");
        StartCoroutine("Stop");
        //StartCoroutine(Stop());
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
        StartCoroutine("HomingMissile");
        StartCoroutine("Stop");
        //StartCoroutine(Stop());
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
