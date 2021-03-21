using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehaviourImpl : BaseMono, PlayerBehaviour
{
    private const int dieCoordinat = -7;
    private int playerSpeed = 6;
    private bool isGrounded;
    private static int playerJumpPower = 390;
    private float moveX;
    private const int groundLayer = 3;


    void Update()
    {
        Death();
        MovePlayer();
    }

    void MovePlayer()
    {
        //controllers and directions
        moveX = CrossPlatformInputManager.GetAxis("Horizontal");
        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //animation of running
        GetComponent<Animator>().SetBool("isRunning", moveX != 0);
        GetComponent<Animator>().SetBool("isJumping", !isGrounded);

        gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
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

    void Death()
    {
        if (gameObject.transform.position.y < dieCoordinat)
        {
            MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().openProgressBar();
        }
    }
}