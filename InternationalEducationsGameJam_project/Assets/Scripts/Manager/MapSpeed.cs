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


        RectTransform a = GetComponent<RectTransform>();

        float b = a.anchoredPosition.x;
        Vector2 apos = a.anchoredPosition;
        Debug.Log(b);
        b = Mathf.Clamp(b, -175.5f, 184.3f);
        
        float c = a.anchoredPosition.y;
        c = Mathf.Clamp(c, -175.5f, 152);
        apos.y = c;
        apos.x = b;

        a.anchoredPosition = apos;
        //a.rect. (b,c,a.rect.width,a.rect.height);
        

    }
    public void ChangePlayerSpeed(int speed)
    {
        GeneralManager.m_Instance.m_Player.GetComponent<PlayerMovement>().m_player.m_Speed = speed;
    }
}
