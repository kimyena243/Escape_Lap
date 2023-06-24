using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1.4f);
        boxCollider.enabled = true;
        StartCoroutine(Delete());
        StartCoroutine(Stop());
    }
    IEnumerator Delete()
    {
        Transform parentTransform = transform.parent;
        yield return new WaitForSeconds(1.8f);
        Destroy(parentTransform.gameObject);
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1.0f);
        boxCollider.enabled = false;
    }
}