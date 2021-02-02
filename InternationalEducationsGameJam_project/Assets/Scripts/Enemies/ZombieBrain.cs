using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBrain : MonoBehaviour
{
    [Header("Enemy Stats")]
    public ScriptableEnemy m_EnemyInput; //This EnemyStats
    private ScriptableEnemy m_Enemy; //This m_Stats
    public void Awake()
    {
        m_Enemy = Instantiate(m_EnemyInput);
    }

    public void Update()
    {
        
    }
}
