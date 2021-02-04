using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtonsManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(ChosenMap.m_ChosenMap);
    }
    public void MapOne()
    {
        ChosenMap.m_ChosenMap = "MainScene";
    }
    public void MapTwo()
    {
        ChosenMap.m_ChosenMap = "SecondMap";
    }
    public void SettingsButton()
    {
        Debug.Log("Doing nothing right now");
    }
    public void MapButton()
    {
        SceneManager.LoadScene("MapScene");
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
