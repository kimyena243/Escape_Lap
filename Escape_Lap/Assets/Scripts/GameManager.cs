using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    public AudioSource BGM;
    public string StageWin;
    public string StageDefeat;
    public bool Boss;
    public static bool Playing;
    public static float HP;

    void Start()
    {
        HP = 100;
        Playing = true;
    }

    void Update()
    {
        if (Playing)
        {
            HP -= Time.deltaTime * 5;
        }

        if (MapMove.GoalCount >= 3 && !Boss)
        {
            SceneManager.LoadScene(StageWin);
        }

        if (HP <= 0)
        {
            SceneManager.LoadScene(StageDefeat);
        }

        pauseGame();
    }

    public void ContinueBtn()
    {
        Time.timeScale = 1f;
        Invoke("Continue", 1.0f);
    }

    public void GiveUpBtn()
    {
        Time.timeScale = 1f;
        Invoke("GiveUp", 1.0f);
    }

    private void Continue()
    {
        
        pauseUI.SetActive(false);
        Playing = true;
    }

    private void GiveUp()
    {
        
        SceneManager.LoadScene("StartScene");
    }

    private void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseUI.activeSelf)
            {
                pauseUI.SetActive(false);
                Playing = true;
                Time.timeScale = 1f;

            }
            else
            {
                pauseUI.SetActive(true);
                Playing = false;
                Time.timeScale = 0f;
            }
        }
    }
}
