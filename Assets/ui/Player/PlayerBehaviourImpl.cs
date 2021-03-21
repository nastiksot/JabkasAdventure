using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehaviourImpl : BaseMono
{
    private const int dieCoordinat = -7;
    private int playerSpeed = 6;
    private bool isGrounded;
    public static int playerJumpPower = 390;
    private float moveX;
    private const int groundLayer = 3;


    void Update()
    {
        PlayerRayCast();
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
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer && isGrounded)
        {
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //checks collision of objects
        if (collision.gameObject.layer == groundLayer && !isGrounded || collision.gameObject.GetComponent<EnemyBehaivourImpl>())
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
    void PlayerRayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
         
        if (hit.distance <1f && hit.collider.CompareTag("Enemy") )
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (playerJumpPower * 1.5f));
            //die animation of enemy
            //enemyKill.Play();
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<EnemyBehaivourImpl>().enabled = false;
        }
    }
}