using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourImpl : BaseMono, PlayerBehaviour
{
    public int playerSpeed = 10;
    public static bool isGrounded;
    public static int playerJumpPower = 390;

    private float moveX;


    // Update is called once per frame
    void Update()
    {
        MoveFrog();
    }

    void MoveFrog()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            JumpFrog();
        }

        //ANIMATION
        // if (_moveX != 0)
        // {
        //     GetComponent<Animator>().SetBool("isRunning", true);
        // }
        // else
        // {
        //     GetComponent<Animator>().SetBool("isRunning", false);
        // }

        //DIRECTION
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // if (isGrounded)
        // {
        //     //jumping anmation
        //     GetComponent<Animator>().SetBool("isJumping", false);
        // }

        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }


    void JumpFrog()
    {
        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
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
    
}
