using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //ScriptableObject
    private ScribtablePlayer m_player;

    //Rb
    private Rigidbody2D rb;

    //Vector
    private Vector2 Axis;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_player = GetComponent<PlayerHealth>().ReturnPlayerStats();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Axis.x = Input.GetAxis("Horizontal");
        Axis.y = Input.GetAxis("Vertical");

        rb.velocity = Axis * m_player.m_Speed * Time.deltaTime;

    }
}
