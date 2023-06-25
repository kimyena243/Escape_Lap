using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobyManager : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject OptionUI;
    public GameObject StageUI;
    public Button Stage02;
    public Button Stage03;

    private bool Option;
    private bool Stage;

    void Update()
    {
        InputBack();
        InputCheat();
    }

    public void PlayBtn()
    {
        Stage = true;
        Invoke("ChangeStage", 1.0f);
    }

    public void OptionBtn()
    {
        Option = true;
        Invoke("ChangeOption", 1.0f);
    }

    public void ExitBtn()
    {
        Invoke("QuitGame", 1.0f);
    }

    public void BackUI()
    {
        if (Option)
        {
            Option = false;
            Invoke("ChangeMain", 1.0f);
        }
        else if (Stage)
        {
            Stage = false;
            Invoke("ChangeMain", 1.0f);
        }
    }

    public void Stage01Btn()
    {
        Invoke("LoadStage01", 1.0f);
    }

    public void Stage02Btn()
    {
        Invoke("LoadStage02", 1.0f);
    }

    public void Stage03Btn()
    {
        Invoke("LoadStage03", 1.0f);
    }

    private void ChangeStage()
    {
        if (Stage)
        {
            MainUI.SetActive(false);
            StageUI.SetActive(true);
        }
    }

    private void ChangeOption()
    {
        if (Option)
        {
            MainUI.SetActive(false);
            OptionUI.SetActive(true);
        }
    }

    private void ChangeMain()
    {
        if (!Stage && !Option)
        {
            OptionUI.SetActive(false);
            StageUI.SetActive(false);
            MainUI.SetActive(true);
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void InputBack()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackUI();
        }
    }

    private void LoadStage01()
    {
        SceneManager.LoadScene("Stage01");
    }

    private void LoadStage02()
    {
        SceneManager.LoadScene("Stage02");
    }

    private void LoadStage03()
    {
        SceneManager.LoadScene("Stage03");
    }

    private void InputCheat()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Stage02.interactable = true;
            Stage03.interactable = true;
        }
    }
}
