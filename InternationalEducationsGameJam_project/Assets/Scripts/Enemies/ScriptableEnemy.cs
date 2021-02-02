using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ZombieType", menuName = "Zombie")]
public class ScriptableEnemy : ScriptableObject
{
    [Header("Health")]
    public int m_Health = 100;
    [Header("Movement")]
    public int m_MovementSpeed = 10;
    [Header("Attacking")]
    public int m_AttackRange = 3; //Attack range of this Unit
    public int m_AttackDamage = 10; //Damage Of this unit.
    public int m_VisionRange = 10; //VisionRange of this unit.
}
