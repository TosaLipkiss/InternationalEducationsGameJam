using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenMap : MonoBehaviour
{
    public static string m_ChosenMap = "MainScene";
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
