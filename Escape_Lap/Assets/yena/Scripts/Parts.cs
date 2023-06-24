using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
       if(objectName == "Boss_D" && gameObject.activeSelf == false) // 마지막 파츠 없어질때 (승리 조건)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayerBullet")) //플레이어 총알에맞았을때
        {
            //PlayerBulletScript playerBulletScript = collision.gameObject.GetComponent<PlayerBulletScript>();
            Hp -= 10; //총알 데미지 변수 가져와서 줄이기
            

        }
    }
}
