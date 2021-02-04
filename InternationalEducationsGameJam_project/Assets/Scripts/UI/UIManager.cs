using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

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

    [Header("Score")]
    public string m_DefaultScoreText;
    [SerializeField]private TMP_Text m_ScoreText;
    public Action<int> m_OnScoreChanged;

    public GameObject victoryScreen;
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
    private void Start()
    {
        if (m_ScoreText != null)
        {
        m_ScoreText.text = m_DefaultScoreText + "0"; // Sets Standard Text
        m_OnScoreChanged += OnScoreChange; //Subscribe to function
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
    #region UICHANGE
    private void OnScoreChange(int Score)
    {
        m_ScoreText.text = m_DefaultScoreText + Score + "/100";
    }
    public void Victory()
    {
        Time.timeScale = 0;
        victoryScreen.SetActive(true);
    }
    #endregion
    #region UIBUTTONS
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
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
