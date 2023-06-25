using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public string Stage;

    public void LobbyBtn()
    {
        Invoke("LoadLobby", 1.0f);
    }

    public void StageBtn()
    {
        Invoke("LoadStage", 1.0f);
    }

    private void LoadLobby()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void LoadStage()
    {
        SceneManager.LoadScene(Stage);
    }
}
