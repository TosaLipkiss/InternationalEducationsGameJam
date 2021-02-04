using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    bool facingRight = true;
    float directionX = 0.0f;
    float runSpeed = 0.5f;

    //ScriptableObject
    public ScribtablePlayer m_player; //use this

    //Rb
    private Rigidbody2D rb;

    //Vector
    private Vector3 axis;

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        m_player = GetComponent<PlayerHealth>().ReturnPlayerStats();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        axis.x = Input.GetAxis("Horizontal");
        if (axis.x == Input.GetAxis("Horizontal"))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
        }

        axis.y = Input.GetAxis("Vertical");
        if (axis.x == Input.GetAxis("Vertical"))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
        }

        rb.velocity = axis * m_player.m_Speed * Time.deltaTime;

        //Face direction in X axis
        directionX = Input.GetAxisRaw("Horizontal") * runSpeed;
        FlipPlayer(directionX);
    }

    public void FlipPlayer(float directionX)
    {
        if (directionX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (directionX > 0)
            GetComponent<SpriteRenderer>().flipX = false;
    }
}
