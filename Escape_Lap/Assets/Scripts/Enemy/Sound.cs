using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    
    private AudioSource audioPlay;
    // Start is called before the first frame update
    void Start()
    {
        audioPlay = GetComponent<AudioSource>();
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            audioPlay.Play();
            yield return new WaitForSecondsRealtime(5f);
        }
    }
}