using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    float speed = 4;
    public float jumpPower;
    bool isJumping;
    float horizontalInput;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
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
            Debug.Log("Jump!");
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            //rb.AddForce(new Vector2(0, 1 * jumpPower), ForceMode2D.Impulse);
            isJumping = false;
        }

    }
}
