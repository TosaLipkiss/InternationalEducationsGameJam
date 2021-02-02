using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ZombieType", menuName = "Create new Zombie")]
public class ScriptableEnemy : ScriptableObject
{
    [Header("Health")]
    public int m_Health = 100; //The Health of this Unit
    [Header("Movement")]
    public int m_MovementSpeed = 10; //The movementSpeed of this unit
    [Header("Attacking")]
    public int m_AttackRange = 3; //Attack range of this Unit
    public int m_AttackDamage = 10; //Damage Of this unit.
    public int m_VisionRange = 10; //VisionRange of this unit.
    [Header("Score")]
    [Tooltip("Score That you get from killing this unit")]
    public int m_Score = 100; //The Score this unit gives upon dying.
}
