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
    public static int playerJumpPower = 390;

    private float moveX;
    private bool isGrounded;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        //CheckDeath();
        PlayerMovement();
    }

    private void PlayerMovement()
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
            new Vector2(moveX * PlayerCharacteristics.PLAYER_SPEED, playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        playerRigidbody.AddForce(Vector2.up * playerJumpPower);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Layers.groundLayer && isGrounded)
        {
            isGrounded = !isGrounded;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks collision of objects
        if (collision.gameObject.layer == Layers.groundLayer && !isGrounded || !collision.gameObject.GetComponent<EnemyBehaivourImpl>())
        {
            isGrounded = !isGrounded;
        }
    }


    private void CheckDeath()
    {
        if (gameObject.transform.position.y < PlayerCharacteristics.DIE_COORDINAT)
        {
            MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenProgressBar();
        }
    }
}