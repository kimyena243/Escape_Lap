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
        ////�÷��̾� ã�� ���ʿ�������
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

        if (collision.CompareTag("Delete")) //���� ������ ������ �� ����
        {
            Destroy(this.gameObject);
        }
        //if (collision.CompareTag("PlayerBullet")) //�÷��̾� �Ѿ˿��¾�����
        //{
        //    PlayerBulletScript playerBulletScript = collision.gameObject.GetComponent<PlayerBulletScript>();
        //    Hp -= playerBulletScript.Damage; //�Ѿ� ������ ���� �����ͼ� ���̱�
        //    Delete();

        //}
        if (collision.CompareTag("Player")) //�÷��̾�� �浹 �� ������ ���ϱ�
        {
            Debug.Log("�浹");

            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                playerScript.Hp -= Damage; // �÷��̾��� HP�� ���ҽ�Ŵ
            }
           

        }
    }



}
