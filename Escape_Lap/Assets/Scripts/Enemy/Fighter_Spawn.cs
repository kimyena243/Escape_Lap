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
    [SerializeField] private float B_Time;
    [SerializeField] private float O_Time;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3[4];
        rot = new Quaternion[4]; 

        pos[0] = new Vector3(-2.5f, 5.0f, 0f); // 왼쪽위
        rot[0] = Quaternion.Euler(0f, 0f, 208f);
        pos[1] = new Vector3(2.5f, 5.0f, 0f); //오른쪽 위
        rot[1] = Quaternion.Euler(0f, 0f, 152f);
        pos[2] = new Vector3(-2.5f, -5.0f, 0f);//왼쪽 아래
        rot[2] = Quaternion.Euler(0f, 0f, -28f);
        pos[3] = new Vector3(2.5f, -5.0f, 0f); // 오른쪽 아래
        rot[3] = Quaternion.Euler(0f, 0f, 28f);

        StartCoroutine(SpawnBasic());
        StartCoroutine(SpawnOther());
    }
    
    IEnumerator SpawnBasic()
    {
        while(true)
        {
           

            B_random = Random.Range(0, 5);
            Instantiate(BasicPattern[B_random]);
            yield return new WaitForSeconds(B_Time);
        }
    }   
    IEnumerator SpawnOther()
    {
        while(true)
        {
            yield return new WaitForSeconds(O_Time);

            O_random = Random.Range(0, 3);
            
            if (O_random == 0)
            {
                //float x = Random.Range(-2.5f, 2.5f);
                Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), -5.0f, 0f);
                Instantiate(OtherPattern[O_random], pos, Quaternion.identity);

            }
            if (O_random == 1)
            {
            
                Vector3 pos = new Vector3(0f, -5.0f, 0f);
                Instantiate(OtherPattern[O_random], pos, Quaternion.identity);

            }
            if (O_random == 2)
            {
                int ran = Random.Range(0, 4);      
                
                Instantiate(OtherPattern[O_random], pos[ran], rot[ran]);
              
            }

            
        }
    }
}
