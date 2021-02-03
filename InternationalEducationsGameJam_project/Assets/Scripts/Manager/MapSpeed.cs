using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpeed : MonoBehaviour
{
    public ScribtablePlayer m_stats;

    bool facingRight = true;
    float directionX = 0.0f;
    float runSpeed = 0.5f;

    //Rb
    private Rigidbody2D rb;

    //Vector
    private Vector3 axis;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
      
    }
    private void Update()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");
        rb.velocity = axis * m_stats.m_Speed * Time.deltaTime;

        //Face direction in X axis
    }
    public void ChangePlayerSpeed(int speed)
    {
        GeneralManager.m_Instance.m_Player.GetComponent<PlayerMovement>().m_player.m_Speed = speed;
    }
}
