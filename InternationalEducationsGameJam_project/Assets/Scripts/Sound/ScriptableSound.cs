using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundType", menuName = "Create new Sound")]
public class ScriptableSound : ScriptableObject
{
    [Header("AudioList")]
    [Tooltip("Add Audio and Name appropiatly.")]
    public List<SoundList> m_SoundType;
}
[System.Serializable]
public class SoundList
{
    public List<AudioClip> m_AudioList;
    public string AudioType;
}
