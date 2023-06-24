using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    public static bool Playing;
    public static float HP;

    void Start()
    {
        HP = 100;
        Playing = true;
    }

    void Update()
    {
        if(Playing)
        {
            HP -= Time.deltaTime * 5;
        }

        pauseGame();
    }

    private void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseUI.activeSelf)
            {
                pauseUI.SetActive(false);
                Playing = true;
            }
            else
            {
                pauseUI.SetActive(true);
                Playing = false;
            }
        }
    }
}
