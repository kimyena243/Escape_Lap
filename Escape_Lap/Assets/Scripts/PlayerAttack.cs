using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject PBullet;
    public float demerit;

    void Start()
    {
        
    }
    
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.Playing)
        {
            Instantiate(PBullet, transform.position, Quaternion.identity);
            GameManager.HP -= demerit;
        }
    }
}
