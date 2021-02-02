using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBrain : MonoBehaviour, IAttackable
{
    #region Variables
    [Header("Enemy Stats")]
    public ScriptableEnemy m_EnemyStats; //This EnemyStats
    private ScriptableEnemy m_Enemy; //This m_Stats

    [Header("Sounds")]
    private AudioClip m_Death; // Sound of Death
    private AudioClip m_Attack; // Sound of an Attack
    private AudioClip m_Breathing; // Sound of the Zombie Breathing
    private AudioClip m_Growl;
    private AudioSource m_AudioSource;
    #endregion
    public void Awake()
    {
        m_Enemy = Instantiate(m_EnemyStats); // Instantiate a new Stats so it doesn't edit the static old stats.
    }
    private void Update()
    {
        if (GetComponent<Renderer>().isVisible)
        {
            PlaySound(m_Breathing);
        }  
    }
    
    #region Sound
    public void AssignSound(AudioClip Death, AudioClip Attack, AudioClip Breathing, AudioClip Growl)
    {
        //Assigning Value's
        m_Death = Death;
        m_Attack = Attack;
        m_Breathing = Breathing;
        m_Growl = Growl;
        m_AudioSource = GetComponent<AudioSource>(); //Get Source
    }
    private IEnumerator PlaySound(AudioClip Clip)
    {
        m_AudioSource.clip = Clip;
        m_AudioSource.Play();
        yield return new WaitForSeconds(m_AudioSource.clip.length);
    }
    #endregion
    #region IAttackable
    public void TakeDamage(int damage)
    {
        if (m_Enemy.m_Health - damage <= 0)
            Death();
        else
        {
            m_Enemy.m_Health -= damage; //Take Damage
            PlaySound(m_Growl);
        }
    }
    public void Death()
    {
        GameStats.m_Instance.Addscore(m_Enemy.m_Score); // Add Score
        gameObject.SetActive(false); // Set the object False and return it to the object pool
    }
    #endregion
}
