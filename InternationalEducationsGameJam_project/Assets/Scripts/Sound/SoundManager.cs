using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager m_Instance;
    [Header("Player")]
    public List<ScriptableSound> m_PlayerSounds;
    [Header("Enemies")]
    public List<ScriptableSound> m_ZombieSounds; 
    [Header("Enviroment")]
    public List<ScriptableSound> m_EnviromentSound;

    [Header("Zombie Sounds")]
    [System.NonSerialized]public bool m_ZombieSoundActive = false; 
    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
    }
}
