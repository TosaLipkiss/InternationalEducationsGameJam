using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UI
{
    public GameObject m_Parent; //Parent Object
    public string m_ObjectName; //Name Of UI
}
public class UIManager : MonoBehaviour
{
    public static UIManager m_Instance; //Singleton

    [Header("UI Lists")]
    [Tooltip("Sets the UI Inactive, Automatically adds it to the ALLUI list ")]
    public List<UI> m_SetInActive; //Parents of the UI and their names.
    [Tooltip("All UI goes in here")]
    public List<UI> m_AllUI; //All UI
    
    private void Awake()
    {
        if (m_Instance == null) //Checks if Instance == nul;
            m_Instance = this;

        if (m_SetInActive != null) 
        {
            for (int i = 0; i < m_SetInActive.Count; i++)
            {
                m_AllUI.Add(m_SetInActive[i]);//Adds UI to general list
                m_SetInActive[i].m_Parent.SetActive(false); //Sets all UI inactive
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (UI Pause in m_SetInActive)
            {
                if (Pause.m_ObjectName == "Pause")
                {
                    Pause.m_Parent.SetActive(true); 
                    Time.timeScale = 0;
                    break;
                }
            }
        }
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Resume()
    {
        foreach (UI Pause in m_AllUI)
        {
            if (Pause.m_ObjectName == "Pause")
            {
                Pause.m_Parent.SetActive(false);
                break;
            }
        }
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit(0);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
