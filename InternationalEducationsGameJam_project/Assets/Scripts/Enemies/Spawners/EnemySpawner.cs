using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
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
    public void StartWave()
    {
        m_WaveCoroutine = SpawnWave();
        StartCoroutine(m_WaveCoroutine);
    }
    public IEnumerator SpawnWave()
    {
        while (true)
        {
            int WaveIndex = Random.Range(0, Waves.Count);
            for (int i = 0; i < Waves[WaveIndex].m_Wave.Count; i++)
            {
                GameObject EnemyUnit = ObjectPooling.m_Instance.GetPooledObject(Waves[WaveIndex].m_Wave[i], m_Spawnlocation); //Spawns an Enemy Unit and gives the location.
                
                yield return new WaitForSeconds(m_DelayUnit);
            }
            yield return new WaitForSeconds(m_DelayWave);
        }
    }
}
