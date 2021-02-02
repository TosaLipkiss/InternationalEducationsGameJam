using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats m_Instance; //Singeton
    private int m_Score; //The overall score of the player
    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
    }
    public void Addscore(int AddAmount)
    {
        m_Score += AddAmount;
    }
}
