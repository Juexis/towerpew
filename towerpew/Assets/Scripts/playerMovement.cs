using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    float speed = 4;
    float jumpPower = 75f;
    float gravity = 1f;
    bool isJumping;
    float horizontalInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(isGrounded());
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            isJumping = true;
        }

        
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //moves character based on horizontal input
        rb.velocity = new Vector2(horizontalInput, 0) * speed;

        if (isJumping)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = false;
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.17f, groundLayer);
    }    

}

