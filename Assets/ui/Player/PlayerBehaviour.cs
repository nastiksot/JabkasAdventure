using System;
using System.Collections;
using System.Collections.Generic;
using services.Constants;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehaviour : BaseMono
{
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float playerSpeed = 6; 
 

    private float moveX;
    private bool isGrounded;
 
    private void Update()
    {
        //CheckDeath();
        PlayerMove();
    }

    private void PlayerMove()
    {
        //controllers and directions
        moveX = CrossPlatformInputManager.GetAxis("Horizontal");
        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (moveX < 0.0f)
        {
            playerSprite.flipX = true;
        }
        else if (moveX > 0.0f)
        {
            playerSprite.flipX = false;
        }

        //animation of running
        // GetComponent<Animator>().SetBool("isRunning", moveX != 0);
        // GetComponent<Animator>().SetBool("isJumping", !isGrounded);

        playerRigidbody.velocity =
            new Vector2(moveX * playerSpeed, playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        playerRigidbody.AddForce(Vector2.up * PlayerCharacteristics.PLAYER_JUMP_POWER);
    }

    private void CheckDeath()
    {
        if (gameObject.transform.position.y < PlayerCharacteristics.DIE_COORDINAT)
        {
            MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenProgressBar();
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Layers.GROUND_LAYER && isGrounded)
        {
            isGrounded = !isGrounded;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.layer == Layers.GROUND_LAYER && !isGrounded || !collision.gameObject.GetComponent<EnemyBehaivour>())
        {
            isGrounded = !isGrounded;
        }
    } 
}