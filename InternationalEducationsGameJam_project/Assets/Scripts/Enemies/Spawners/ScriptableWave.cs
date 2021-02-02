using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveType", menuName = "Create new Wave")]
public class ScriptableWave : ScriptableObject
{
    [Header("Wave")]
    public List<GameObject> m_Wave = new List<GameObject>(); //This Wave
}
