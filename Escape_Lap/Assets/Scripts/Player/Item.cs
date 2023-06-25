using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            int ran = Random.Range(0, 10);
            if(ran > 4)
            {
                PlayerAttack.PowerItem = true;
                Destroy(gameObject);
            }
            else
            {
                PlayerAttack.AutoItem = true;
                Destroy(gameObject);
            }
        }
    }

}
