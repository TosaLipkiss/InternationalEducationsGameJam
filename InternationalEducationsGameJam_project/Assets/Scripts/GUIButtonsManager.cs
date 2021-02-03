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
        Debug.Log("Doing nothing right now");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
