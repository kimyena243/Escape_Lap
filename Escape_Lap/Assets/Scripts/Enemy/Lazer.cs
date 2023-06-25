using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public AudioClip shoot;
    private AudioSource audioPlay;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        audioPlay = GetComponent<AudioSource>();
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1.3f);
        audioPlay.clip = shoot;
        audioPlay.Play();
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

    private void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GameManager.HP -= 10.0f;
        }
    }
}