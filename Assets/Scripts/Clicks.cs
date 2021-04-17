using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clicks : MonoBehaviour
{
    int PlayerLevel = 0;
    bool GamePaused = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("ppPlayerLevel"))
        {
            PlayerPrefs.SetInt("ppPlayerLevel", 1);
            PlayerLevel = 1;
        }
        else
        {
            PlayerLevel = PlayerPrefs.GetInt("ppPlayerLevel");
        }
        PlayerPrefs.SetInt("ppSelectedLevel", PlayerLevel);
    }

    void Update()
    {
        if (!GamePaused)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void PauseGame()
    {
        if (!GamePaused)
        {
            GamePaused = true;
            Debug.Log("gamePaused = " + GamePaused);
            return;
        }
        else
        {
            GamePaused = false;
            Debug.Log("gamePaused = " + GamePaused);
            return;
        }
    }

    public void OpenScene(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName);
    }

    public void ResetGame() {
        PlayerPrefs.SetInt("ppPlayerLevel", 1);
        PlayerPrefs.SetInt("ppSelectedLevel", 1);
        PlayerLevel = 1;
        OpenScene("Menu");
    }
}
