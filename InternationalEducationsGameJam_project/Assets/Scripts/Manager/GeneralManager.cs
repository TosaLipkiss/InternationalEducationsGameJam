using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager m_Instance;
    public GameObject m_Player;
    public Animator m_RevivedAnimation;
    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        m_Player = FindObjectOfType<PlayerMovement>().gameObject;
    }
}
