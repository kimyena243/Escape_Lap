using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rd;
    public float Speed;
    public float Hp;
    public float Damage;
    public GameObject player;
    public GameObject Bullet;
    Transform tr;
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
    virtual public void Move()
    {
        rd.AddForce(Vector2.down * Speed);
    }
    virtual public void Shoot()
    {
        Instantiate(Bullet, tr);

        
    }

    void Attack()
    {
        Debug.Log("ÇÃ·¹ÀÌ¾î¶û Ãæµ¹");
       
        
    }

    void Delete()
    {

      
       Destroy(this.gameObject);
       Debug.Log("¸ÓÂ¡");
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        
            Attack();

        }

        if (collision.CompareTag("Delete"))
        {

            Delete();
        }



    }
  
}
