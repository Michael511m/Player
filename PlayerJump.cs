using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Vector2 jumpForce = new Vector2(0f, 2500f);

    bool isJump = false;
    int JumpMax = 1;
    int JumpNumber = 0;

    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
            JumpNumber++;
        }
    }
    private void FixedUpdate()
    {
        Jump();
    }
    void Jump()
    {
        if (isJump && JumpNumber <= JumpMax)
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
            
        }
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            JumpNumber = 0;
        }

        isJump = false;


    }
}
