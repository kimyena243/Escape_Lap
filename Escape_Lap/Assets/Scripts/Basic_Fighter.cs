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
    [SerializeField] private GameObject Player;
    [SerializeField] protected GameObject Bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
        Move();
        ShootStart();
        
    }

    // Update is called once per frame
    void Update()
    {
       
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
            Instantiate(Bullet, tr);
            yield return new WaitForSeconds(1.0f);
        }
    }
    void Attack()
    {
        Debug.Log("플레이어랑 충돌");
       
        
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
        if (collision.CompareTag("Player"))
        {
            Attack(); // 플레이어hp가져와서 줄이기
        }

        if (collision.CompareTag("Delete")) //범위 밖으로 나갔을 때 삭제
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("PlayerBullet")) //플레이어 총알에맞았을때
        {
            Hp--; //플레이어 데미지 가져와서 줄이기
            Delete();

        }

    }



}
