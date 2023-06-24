using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Fighter : MonoBehaviour
{
    protected Rigidbody2D rd;
    protected Transform tr;
    [SerializeField] protected float Speed;
    [SerializeField] private float Hp;
    [SerializeField] private float Damage;
    [SerializeField] protected float BulletSpeed;
    [SerializeField] protected GameObject Bullet;

    // Start is called before the first frame update
    virtual public void Start()
    {
        ////플레이어 찾기 안필요할지도
        //GameObject Player = GameObject.FindWithTag("Player");
        //if(Player!=null)
        //{
        //    PlayerScript playerScript = Player.GetComponent<PlayerScript>();
        //}

    
        rd = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
        Move();
        ShootStart();
        
    }

    // Update is called once per frame
    void Update()
    {
        Delete();
    }
    virtual public void Move() // 기본 이동 위-> 아래
    {
        rd.AddForce(Vector2.down * Speed);
    }
    virtual public void ShootStart() // 기본 공격 
    {
        StartCoroutine(Shoot());

        
    }
    IEnumerator Shoot()
    {
        while(true)
        {
            GameObject bulletObject = Instantiate(Bullet, tr);
            bulletObject.GetComponent<Bullet>().Move();

            yield return new WaitForSeconds(BulletSpeed);
        }
    }


    void Delete()
    {
        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Delete")) //범위 밖으로 나갔을 때 삭제
        {
            Destroy(this.gameObject);
        }
        //if (collision.CompareTag("PlayerBullet")) //플레이어 총알에맞았을때
        //{
        //    PlayerBulletScript playerBulletScript = collision.gameObject.GetComponent<PlayerBulletScript>();
        //    Hp -= playerBulletScript.Damage; //총알 데미지 변수 가져와서 줄이기
        //    Delete();

        //}
        if (collision.CompareTag("Player")) //플레이어랑 충돌 시 데미지 가하기
        {
            Debug.Log("충돌");

            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                playerScript.Hp -= Damage; // 플레이어의 HP를 감소시킴
            }
           

        }
    }



}
