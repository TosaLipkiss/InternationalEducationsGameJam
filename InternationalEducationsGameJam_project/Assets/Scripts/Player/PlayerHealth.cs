using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IAttackable
{
    //ScriptableObject
    public ScribtablePlayer m_publicplayer;
    public ScribtablePlayer m_playerstats; //editable stats <--

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
        gameObject.SetActive(false);
        yield return null;
    }
    #endregion

    public ScribtablePlayer ReturnPlayerStats()
    {
        return m_playerstats;
    }

}
