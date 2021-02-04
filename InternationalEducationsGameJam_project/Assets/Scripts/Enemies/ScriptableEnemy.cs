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
    public int m_WanderRange = 10; //Wandering Range of this Unit
    [System.NonSerialized] public bool m_Arrived = false;//Has this unit arrived at their target location?
    public LayerMask m_WallMask; //WallsMask
    public LayerMask m_PlayerMask;//PlayerMask
    [Header("Attacking")]
    public int m_AttackRange = 3; //Attack range of this Unit
    public int m_AttackDamage = 10; //Damage Of this unit.
    public int m_VisionRange = 10; //VisionRange of this unit.
    public int m_AttackSpeed = 2; //Every X seconds this unit Attacks

    [System.NonSerialized]public int m_CurrentTimer = 2; //A Timer For Attacking 
    [System.NonSerialized]public Vector2 m_TargetPosition;
    [System.NonSerialized]public bool m_SpottedEnemy = false; //Target Spotted
    [System.NonSerialized] public GameObject m_Target; // The Current Target
    [Header("Score")]
    [Tooltip("Score That you get from killing this unit")]
    public int m_Score = 1; //The Score this unit gives upon dying.
}
