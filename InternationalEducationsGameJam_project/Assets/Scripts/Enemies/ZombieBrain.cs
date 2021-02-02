using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBrain : MonoBehaviour, IAttackable
{
    [Header("Enemy Stats")]
    public ScriptableEnemy m_EnemyInput; //This EnemyStats
    private ScriptableEnemy m_Enemy; //This m_Stats
    public void Awake()
    {
        m_Enemy = Instantiate(m_EnemyInput); // Instantiate a new Stats so it doesn't edit the static old stats.
    }
    public void TakeDamage(int damage)
    {
        if (m_Enemy.m_Health - damage <= 0)
            Death();
        else
        {
            m_Enemy.m_Health -= damage; //Take Damage
        }
    }
    public void Death()
    {
        GameStats.m_Instance.Addscore(m_Enemy.m_Score); // Add Score
        gameObject.SetActive(false); // Set the object False and return it to the object pool
    }
}
