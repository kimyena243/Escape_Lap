using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter_Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] BasicPattern;
    [SerializeField] private GameObject[] OtherPattern;
    private int B_random;
    private int O_random;
    private Vector3[] pos;
    private Quaternion[] rot;
    [SerializeField] private float Time;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3[4];
        rot = new Quaternion[4]; 

        pos[0] = new Vector3(-2.0f, 4.2f, 0f); // 왼쪽위
        rot[0] = Quaternion.Euler(0f, 0f, -135f);
        pos[1] = new Vector3(2.0f, 4.2f, 0f); //오른쪽 위
        rot[1] = Quaternion.Euler(0f, 0f, 135f);
        pos[2] = new Vector3(-2.0f, -4.2f, 0f);//왼쪽 아래
        rot[2] = Quaternion.Euler(0f, 0f, -45f);
        pos[3] = new Vector3(2.0f, -4.2f, 0f); // 오른쪽 아래
        rot[3] = Quaternion.Euler(0f, 0f, 45f);

        StartCoroutine(SpawnBasic());
        StartCoroutine(SpawnOther());
    }
    
    IEnumerator SpawnBasic()
    {
        while(true)
        {
            B_random = Random.Range(0, 5);
            Instantiate(BasicPattern[B_random]);
            yield return new WaitForSeconds(Time);
        }
    }   
    IEnumerator SpawnOther()
    {
        while(true)
        {
            O_random = Random.Range(0, 3);
            Debug.Log(O_random);

            if (O_random == 0 || O_random == 1)
            {
                //float x = Random.Range(-2.5f, 2.5f);
                Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), -5.5f, 0f);
                Instantiate(OtherPattern[O_random], pos, Quaternion.identity);

            }
            if (O_random == 2)
            {
                int ran = Random.Range(0, 4);

        

                
                
                Instantiate(OtherPattern[O_random], pos[ran], rot[ran]);
              
            }

            yield return new WaitForSeconds(Time);
        }
    }
}
