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
    virtual public void Move() // �⺻ �̵� ��-> �Ʒ�
    {
        rd.AddForce(Vector2.down * Speed);
    }
    virtual public void ShootStart() // �⺻ ���� 
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
        Debug.Log("�÷��̾�� �浹");
       
        
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
            Attack(); // �÷��̾�hp�����ͼ� ���̱�
        }

        if (collision.CompareTag("Delete")) //���� ������ ������ �� ����
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("PlayerBullet")) //�÷��̾� �Ѿ˿��¾�����
        {
            Hp--; //�÷��̾� ������ �����ͼ� ���̱�
            Delete();

        }

    }



}
