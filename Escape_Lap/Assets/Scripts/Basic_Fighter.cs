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
    virtual public void Move() // �⺻ �̵� ��-> �Ʒ�
    {
        rd.AddForce(Vector2.down * Speed);
    }
    virtual public void Shoot() // �⺻ ���� 
    {
        Instantiate(Bullet, tr);

        
    }

    void Attack()
    {
        Debug.Log("�÷��̾�� �浹");
       
        
    }

    void Delete()
    { 
       Destroy(this.gameObject);
       Debug.Log("��¡");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Attack();
        }

        if (collision.CompareTag("Delete")) //���� ������ ������ �� ����
        {
            Delete();
        }

    }

    
  
}
