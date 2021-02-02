using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Waves")]
    public List<ScriptableWave> Waves = new List<ScriptableWave>(); //All waves in this Spawner.

    [Header("SpawnerVariables")]
    [Tooltip("Delay per Wave")]
    public int m_Delay; //Delay for each wave.
    private IEnumerator m_WaveCoroutine; //The Coroutine For this wave.

    public void StartWave()
    {
        m_WaveCoroutine = SpawnWave(m_Delay);
        StartCoroutine(m_WaveCoroutine);
    }
    public IEnumerator SpawnWave(int DelayWave)
    {
        while (true)
        {

          yield return new WaitForSeconds(DelayWave);
        }
    }
}
