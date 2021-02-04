using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtonsManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SettingsButton()
    {
        Debug.Log("Doing nothing right now");
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
