using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Health
{
    public GameObject m_Health;
    public bool HalfHeart;
}
public class PlayerHealth : MonoBehaviour, IAttackable
{
    public GameObject gameOverScreen;
    //ScriptableObject
    public ScribtablePlayer m_publicplayer;
    public ScribtablePlayer m_playerstats; //editable stats <--

    public List<Health> m_Health;
    public Sprite m_HalfHeart;
    public Sprite m_WholeHeart;
    private void Awake()
    {
        Time.timeScale = 1;
        m_playerstats = Instantiate(m_publicplayer);
    }

    #region Attackable
    public void TakeDamage(int Damage)
    {
        if (m_playerstats.m_Health - Damage <= 0)
        {
            RemoveHeart();
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            StartCoroutine(Death());
        }
        else
        {
            m_playerstats.m_Health -= Damage;
            RemoveHeart();
        }
    }

    public void RemoveHeart()
    {
        for (int i = m_Health.Count - 1; i < m_Health.Count; i--)
        {
            if (m_Health[i].m_Health.activeInHierarchy)
            {
                if (m_Health[i].HalfHeart)
                {
                    Debug.Log("heart");
                    m_Health[i].m_Health.SetActive(false);
                    break;
                }
                else
                {

                    m_Health[i].HalfHeart = true;
                    m_Health[i].m_Health.GetComponent<Image>().sprite = m_HalfHeart;
                    break;
                }
            }
        }
    }
    public void AddHeart(int amount)
    {
        for (int i = 0; i < m_Health.Count; i++)
        {
            if (m_Health[i].m_Health.activeInHierarchy)
            {
                if (m_Health[i].HalfHeart)
                {
                    m_Health[i].HalfHeart = false;
                    m_Health[i].m_Health.GetComponent<Image>().sprite = m_WholeHeart;
                    break;
                }
            }
            else if (!m_Health[i].m_Health.activeInHierarchy)
            {
                m_Health[i].m_Health.SetActive(true);
                break;
            }
        }
        if (m_playerstats.m_Health + amount >= 10)
        {
            m_playerstats.m_Health = 10;
        }
        else
        {
            m_playerstats.m_Health += amount;
        }
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
