using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
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
    private AudioClip m_Growl; // Sound of the zombie Growling
    private AudioSource m_AudioSource; //Audiosource
    //private bool m_PlayingAudioSource = false; //Is The Unit Playing the Audio Source
    [Header("Movement")]
    private Vector2 m_Waypoint; // Waypoint This Target is moving towards.
    #endregion
    private void Awake()
    {
        m_Enemy = Instantiate(m_EnemyStats);
    }
    private void OnEnable()
    {
        StartCoroutine(INewDirection()); //Starts Moving Around
        m_Enemy = Instantiate(m_EnemyStats); // Instantiate a new Stats so it doesn't edit the static old stats.
    }
    private void Update()
    {
        Vector3 trans = transform.position;
        Move();
        CheckIfInCameraVision();
        PlayerInVision();
        RaycastPlayer();

        GetComponent<SpriteRenderer>().flipX = trans.x < transform.position.x;
    }
    #region Movement
    #region Direction
    private IEnumerator INewDirection()
    {
        while (!m_Enemy.m_SpottedEnemy)
        {
            NewDirection();
            yield return new WaitUntil(() => m_Enemy.m_Arrived || m_Enemy.m_SpottedEnemy);
        }
    }
    private void NewDirection()
    {
        NewWayPoint();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, m_Waypoint, m_Enemy.m_WanderRange, m_Enemy.m_WallMask);
        if (hit.distance < 1 && hit.collider != null)
        {
            NewWayPoint();
        }
        else
        {
            //transform.LookAt(m_Waypoint);
            m_Enemy.m_Arrived = false;
        }
    }
    private void NewWayPoint()
    {
        m_Waypoint = new Vector2(Random.Range(transform.position.x - m_Enemy.m_WanderRange, transform.position.x + m_Enemy.m_WanderRange
     ), Random.Range(transform.position.y - m_Enemy.m_WanderRange, transform.position.y + m_Enemy.m_WanderRange));
    }
    #endregion
    private void Move()
    {
        if (!m_Enemy.m_SpottedEnemy)
        {
            //transform.position += transform.TransformDirection(Vector3.forward) * m_Enemy.m_MovementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, m_Waypoint, m_Enemy.m_MovementSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, m_Waypoint) < 0.5)
            m_Enemy.m_Arrived = true;
        }
    }

    public void CheckIfInCameraVision()
    {
        if (GetComponent<Renderer>().isVisible)
        {
          
            if (!SoundManager.m_Instance.m_ZombieSoundActive)
            {
               //StartCoroutine(PlaySound(m_Breathing));
            }
            else
            {
                //transform.LookAt(m_Waypoint);
            }
        }

    }
    private void RaycastPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, GeneralManager.m_Instance.m_Player.transform.position, m_Enemy.m_VisionRange, m_Enemy.m_PlayerMask);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                //transform.LookAt(hit.transform.position);
                m_Enemy.m_SpottedEnemy = true;
                m_Enemy.m_TargetPosition = hit.transform.position;
                m_Enemy.m_Target = hit.collider.gameObject;
                m_Enemy.m_Arrived = true;
            }
        }
    }
    private void PlayerInVision()
    {
        if (m_Enemy.m_SpottedEnemy)
        {
            //transform.position += transform.TransformDirection(Vector3.forward) * m_Enemy.m_MovementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, GeneralManager.m_Instance.m_Player.transform.position, m_Enemy.m_MovementSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, m_Enemy.m_TargetPosition) < 0.1f)
            {

                //Attack();
            }
        }
    }
    #endregion
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
        SoundManager.m_Instance.m_ZombieSoundActive = true;
        yield return new WaitForSeconds(m_AudioSource.clip.length);
        SoundManager.m_Instance.m_ZombieSoundActive = false;
    }
    #endregion
    #region Attack Or Damage
    private void Attack()
    {
        if (m_Enemy.m_CurrentTimer <= 0)
        {
            if (m_Enemy.m_Target.GetComponent<IAttackable>() != null)
            {
                m_Enemy.m_Target.GetComponent<IAttackable>().TakeDamage(m_Enemy.m_AttackDamage);
                m_Enemy.m_CurrentTimer = m_Enemy.m_AttackSpeed;
                PlaySound(m_Attack);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Tongue"))
        {
            Debug.Log("tongue");
            TakeDamage(1);
            GeneralManager.m_Instance.m_Player.GetComponent<PlayerHealth>().AddHeart(1);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IAttackable>().TakeDamage(1);
        }
    }
    public void TakeDamage(int damage)
    {
        if (m_Enemy.m_Health - damage <= 0)
            StartCoroutine(Death());
        else
        {
            m_Enemy.m_Health -= damage; //Take Damage
            PlaySound(m_Growl);
        }
    }
    public IEnumerator Death()
    {
        GameStats.m_Instance.Addscore(m_Enemy.m_Score); // Add Score
        PlaySound(m_Death);

        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().runtimeAnimatorController = GeneralManager.m_Instance.m_RevivedAnimation;
        yield return new WaitForSeconds(m_Death.length);
    }
    #endregion
}
