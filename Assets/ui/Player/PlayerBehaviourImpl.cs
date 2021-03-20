using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehaviourImpl : BaseMono, PlayerBehaviour
{
    private int playerSpeed = 10;
    public bool isGrounded;
    private static int playerJumpPower = 390;
    private float moveX;
    private const int groundLayer = 3;

    // Update is called once per frame
    void Update()
    {
        MoveFrog();
    }

    void MoveFrog()
    {
        //controllers and directions
        moveX = CrossPlatformInputManager.GetAxis("Horizontal");
        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
        {
            JumpFrog();
        }
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
        //ANIMATION
        // if (moveX != 0)
        // {
        //     GetComponent<Animator>().SetBool("isRunning", true);
        // }
        // else
        // {
        //     GetComponent<Animator>().SetBool("isRunning", false);
        // }
 

        // if (isGrounded)
        // {
        //     //jumping anmation
        //     GetComponent<Animator>().SetBool("isJumping", false);
        // }
 
        gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void JumpFrog()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        // GetComponent<Animator>().SetBool("isJumping", true);
    }

    // private void OnCollisionEnter2D(Collision2D col)
    // {
    //     //cheks collision of objects
    //     if (!col.gameObject.CompareTag("Enemy"))
    //     {
    //         isGrounded = true;
    //     }
    // }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer && isGrounded)
        {
            isGrounded = false;
            dlog("Exit");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer
            && !isGrounded)
        {
            isGrounded = true;
        }
    }
}