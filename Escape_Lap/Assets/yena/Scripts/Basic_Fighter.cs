using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Basic_Fighter : MonoBehaviour
{
    protected Rigidbody2D rd;
    protected Transform tr;
    protected SpriteRenderer sr;
    [SerializeField] protected float Speed;
    [SerializeField] protected float Hp;
    [SerializeField] protected float Damage;
    [SerializeField] protected float BulletSpeed;
    [SerializeField] protected GameObject Bullet;
    [SerializeField] protected GameObject Item;
    [SerializeField] private Sprite[] image;
    private string currentSceneName;
    private float screenX = 3.0f;
    private float screenY = 10.0f;
    // Start is called before the first frame update
    virtual public void Start()
    {
        ////�÷��̾� ã�� ���ʿ�������
        //GameObject Player = GameObject.FindWithTag("Player");
        //if(Player!=null)
        //{
        //    PlayerScript playerScript = Player.GetComponent<PlayerScript>();
        //}
        currentSceneName = SceneManager.GetActiveScene().name;
        
        rd = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        if (currentSceneName == "Stage01")
        {
            sr.sprite = image[0];
        }
        else if (currentSceneName == "Stage02")
        {
            sr.sprite = image[1];
        }
        else if (currentSceneName == "Stage03")
        {
            sr.sprite = image[2];
        }
        Move();
        ShootStart();


    }

    // Update is called once per frame
    virtual public void Update()
    {
        Delete();
        Die();

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
        while (true)
        {
            GameObject bulletObject = Instantiate(Bullet, tr);
            bulletObject.GetComponent<Bullet>().Move();

            yield return new WaitForSeconds(BulletSpeed);
        }
    }

    protected void ItemDrop()
    {
        int randomNum = Random.Range(1, 11);
       
        if (randomNum == 1 || randomNum == 2)
        {
            Debug.Log(randomNum);
            GameObject item = Instantiate(Item, tr);
            item.transform.parent = null;
            item.transform.localScale = Vector3.one; // Scale ���� (1, 1, 1)�� ����
        }


    }
    virtual public void Die()
    {
        if (Hp <= 0)
        {
            ItemDrop();

            Destroy(this.gameObject);

            //������
        }
    }
    protected void Delete()
    {
        // �Ѿ��� ���� ��ġ
        Vector3 currentPosition = transform.position;

        // ȭ�� ������ ��� ��� ����
        if (currentPosition.x< -screenX || currentPosition.x> screenX ||
            currentPosition.y< -screenY || currentPosition.y> screenY)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayerBullet")) //�÷��̾� �Ѿ˿��¾�����
        {
            //PlayerBulletScript playerBulletScript = collision.gameObject.GetComponent<PlayerBulletScript>();
            //Hp -= playerBulletScript.Damage; //�Ѿ� ������ ���� �����ͼ� ���̱�
            Hp -= 1; //�Ѿ� ������ ���� �����ͼ� ���̱�
           

        }
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
