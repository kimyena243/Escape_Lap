using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobyManager : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject OptionUI;
    public GameObject StageUI;

    private bool Option;
    private bool Stage;

    void Update()
    {
        InputBack();
    }

    public void PlayBtn()
    {
        MainUI.SetActive(false);
        StageUI.SetActive(true);
        Stage = true;
    }

    public void OptionBtn()
    {
        MainUI.SetActive(false);
        OptionUI.SetActive(true);
        Option = true;
    }

    public void ExitBtn()
    {

    }

    public void BackUI()
    {
        if (Option)
        {
            OptionUI.SetActive(false);
            MainUI.SetActive(true);
            Option = false;
        }
        else if (Stage)
        {
            StageUI.SetActive(false);
            MainUI.SetActive(true);
            Stage = false;
        }
    }

    private void InputBack()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackUI();
        }
    }
}
