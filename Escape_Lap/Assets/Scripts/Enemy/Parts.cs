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
       if(objectName == "Boss_D" && gameObject.activeSelf == false) // ������ ���� �������� (�¸� ����)
        {
            
            Destroy(transform.parent.gameObject);
            SceneManager.LoadScene("Stage03Win");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayerBullet")) //�÷��̾� �Ѿ˿��¾�����
        {
            
            Hp -= 5;
            

        }
    }
}
