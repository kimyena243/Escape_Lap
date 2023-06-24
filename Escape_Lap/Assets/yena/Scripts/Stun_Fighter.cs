using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun_Fighter : Basic_Fighter
{
    [SerializeField] private GameObject StunCircle;
    [SerializeField] private float spawnRangeX = 2.5f; 
    [SerializeField] private float spawnRangeY = 5f; 
   

    // Update is called once per frame
    public override void ShootStart() //  공격 
    {
        StartCoroutine(Stun());


    }
    IEnumerator Stun()
    {
        
        Vector3 randomPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0f, Random.Range(-spawnRangeY, spawnRangeY));
        Instantiate(StunCircle, randomPosition, Quaternion.identity);
        StartCoroutine(S_Delete());
        yield return null;
    }
    public override void Move() //이동 x
    {
        transform.position = transform.position;
    }

    IEnumerator S_Delete()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
       
    }
}
