using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpeed : MonoBehaviour
{
   public void ChangePlayerSpeed(int speed)
    {
        GeneralManager.m_Instance.m_Player.GetComponent<PlayerMovement>().m_player.m_Speed = speed;
    }
}
