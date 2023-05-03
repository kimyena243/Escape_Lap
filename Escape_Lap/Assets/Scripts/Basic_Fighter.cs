using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Fighter : MonoBehaviour
{
    Rigidbody2D rd;
    Transform tr;
    [SerializeField] private float Speed;
    [SerializeField] private float Hp;
    [SerializeField] private float Damage;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
        Move();
        InvokeRepeating("Shoot", 0f,1.0f) ;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    virtual public void Move() // 기본 이동 위-> 아래
    {
        rd.AddForce(Vector2.down * Speed);
    }
    virtual public void Shoot() // 기본 공격 
    {
        Instantiate(Bullet, tr);

        
    }

    void Attack()
    {
        Debug.Log("플레이어랑 충돌");
       
        
    }

    void Delete()
    { 
       Destroy(this.gameObject);
       Debug.Log("머징");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Attack();
        }

        if (collision.CompareTag("Delete")) //범위 밖으로 나갔을 때 삭제
        {
            Delete();
        }

    }

    
  
}
