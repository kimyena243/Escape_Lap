using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parts : MonoBehaviour
{
    [SerializeField] private float Hp;
     private string objectName;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
        objectName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
       if(Hp==0)
        {
           
            gameObject.SetActive(false);
            GameManager.HP += 20.0f;
        }
       if(objectName == "Boss_D" && gameObject.activeSelf == false) // 마지막 파츠 없어질때 (승리 조건)
        {
            
            Destroy(transform.parent.gameObject);
            SceneManager.LoadScene("Stage03Win");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayerBullet")) //플레이어 총알에맞았을때
        {
            
            Hp -= 5;
            

        }
    }
}
