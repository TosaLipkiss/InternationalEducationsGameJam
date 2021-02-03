using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "player", menuName = "Create new player")]
public class ScribtablePlayer : ScriptableObject
{
    [Header("Movement")]
    [Tooltip("The speed the player moves with")]
    public int m_Speed = 4;
    [Header("Health")]
    [Tooltip("this is the amount of lives the player has")]
    public int m_Health = 3;
}
