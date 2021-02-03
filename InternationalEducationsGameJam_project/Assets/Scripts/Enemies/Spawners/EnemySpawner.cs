using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Variables
    [Header("Waves")]
    public List<ScriptableWave> Waves = new List<ScriptableWave>(); //All waves in this Spawner.

    [Header("SpawnerVariables")]
    [Tooltip("Delay per Wave")]
    public int m_DelayWave = 10; //Delay for each wave.

    [Tooltip("Delay Per Unit")]
    public int m_DelayUnit =1; //Delay per Unit.

    private IEnumerator m_WaveCoroutine; //The Coroutine For this wave.

    [Tooltip("Location of where the wave is being Spawned")]
    public Transform m_Spawnlocation;

    [Header("Sounds")]
    private AudioClip m_Death; // Sound of Death
    private AudioClip m_Attack; // Sound of an Attack
    private AudioClip m_Breathing; // Sound of the Zombie Breathing
    private AudioClip m_Growl; // Sound of the zombie Growling
    #endregion
    private void Start()
    {
        StartWave();
    }
    public void StartWave()
    {
        m_WaveCoroutine = SpawnWave();
        StartCoroutine(m_WaveCoroutine);
    }
    public IEnumerator SpawnWave()
    {
        while (true)
        {
            GetRandomSounds(); // Randomizes zombie Sounds
            int WaveIndex = Random.Range(0, Waves.Count);
            for (int i = 0; i < Waves[WaveIndex].m_Wave.Count; i++)
            {
                GameObject EnemyUnit = ObjectPooling.m_Instance.GetPooledObject(Waves[WaveIndex].m_Wave[i].tag, m_Spawnlocation); //Spawns an Enemy Unit and gives the location.
                EnemyUnit.GetComponent<ZombieBrain>().AssignSound(m_Death,m_Attack,m_Breathing,m_Growl); // Assigning Value's
                yield return new WaitForSeconds(m_DelayUnit);
            }
            yield return new WaitForSeconds(m_DelayWave);
        }
    }
    #region Sounds

    public void GetRandomSounds()
    {
        foreach (ScriptableSound SoundList in SoundManager.m_Instance.m_ZombieSounds)
        {
            foreach (SoundList Sounds in SoundList.m_SoundType)
            {
                switch (Sounds.AudioType)
                {
                    case "Death":
                        m_Death = Sounds.m_AudioList[Random.Range(0, Sounds.m_AudioList.Count)];
                        break;
                    case "Breathing":
                        m_Breathing = Sounds.m_AudioList[Random.Range(0, Sounds.m_AudioList.Count)];
                        break;
                    case "ShortAttack":
                        m_Attack = Sounds.m_AudioList[Random.Range(0, Sounds.m_AudioList.Count)];
                        break;
                    case "Growl":
                        m_Growl = Sounds.m_AudioList[Random.Range(0, Sounds.m_AudioList.Count)];
                        break;
                }
            }
        }
    }
    #endregion
}
