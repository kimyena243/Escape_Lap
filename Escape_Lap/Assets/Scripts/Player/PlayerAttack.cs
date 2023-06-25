using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject[] PBullet;
    public GameObject[] ItemProgress;
    public Image[] Shadow;
    public AudioSource AttackSound;

    public float demerit;
    public static bool PowerItem;
    public static bool AutoItem;

    private float[] delayTime = new float[2];
    private float time;

    void Start()
    {
        time = Time.time;
        delayTime[0] = 0.0f;
        delayTime[1] = 0.0f;
        PowerItem = false;
        AutoItem = false;
    }
    
    void Update()
    {
        ItemDelay();
        Attack();

        if (AutoItem)
        {
            AutoAttack();
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.Playing)
        {
            if (PowerItem)
            {
                AttackSound.Play();
                Instantiate(PBullet[1], transform.position, Quaternion.identity);
            }
            else
            {
                AttackSound.Play();
                Instantiate(PBullet[0], transform.position, Quaternion.identity);
            }
            GameManager.HP -= demerit;
        }
    }

    private void AutoAttack()
    {
        if (time + 1.0f < Time.time)
        {
            AttackSound.Play();
            Instantiate(PBullet[2], transform.position, Quaternion.identity);
            time = Time.time;
        }
    }

    private void ItemDelay()
    {
        if (GameManager.Playing)
        {
            if (delayTime[0] > 1)
            {
                PowerItem = false;
                delayTime[0] = 0.0f;
            }
            if (delayTime[1] > 1)
            {
                AutoItem = false;
                delayTime[1] = 0.0f;
            }

            ShowDelay();
        }
    }

    private void ShowDelay()
    {
        if (PowerItem)
        {
            ItemProgress[0].SetActive(true);
            Shadow[0].fillAmount = delayTime[0];
            delayTime[0] += 0.0001f;
        }
        else
        {
            ItemProgress[0].SetActive(false);
        }

        if (AutoItem)
        {
            ItemProgress[1].SetActive(true);
            Shadow[1].fillAmount = delayTime[1];
            delayTime[1] += 0.0001f;
        }
        else
        {
            ItemProgress[1].SetActive(false);
        }
    }
}
