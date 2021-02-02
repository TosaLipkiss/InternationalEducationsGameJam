using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Rb
    private Rigidbody2D rb;

    //Vector
    private Vector2 Axis;

    //Float
    [SerializeField] private float movingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Axis.x = Input.GetAxis("Horizontal");
        Axis.y = Input.GetAxis("Vertical");

        rb.velocity = Axis * movingSpeed;

    }
}
