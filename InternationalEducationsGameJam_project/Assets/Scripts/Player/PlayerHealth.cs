using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IAttackable
{
    //ScriptableObject
    public ScribtablePlayer m_publicplayer;
    private ScribtablePlayer m_playerstats;

    private void Awake()
    {
        m_playerstats = Instantiate(m_publicplayer);
    }

    #region Attackable
    public void TakeDamage(int Damage)
    {
        if (m_playerstats.m_Health - Damage <= 0)
        {
            StartCoroutine(Death());
        }
        else
            m_playerstats.m_Health -= Damage;
    }

    public IEnumerator Death()
    {
        yield return null;
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    public ScribtablePlayer ReturnPlayerStats()
    {
        return m_playerstats;
    }

}
