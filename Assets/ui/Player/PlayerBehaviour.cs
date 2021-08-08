using System;
using DI;
using services.Constants;
using UI.Base;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UI.Player
{
    public class PlayerBehaviour : BaseMono
    {
        [SerializeField] private SpriteRenderer playerSprite;
        [SerializeField] private Rigidbody2D playerRigidbody;

        [Space(6f)] [SerializeField] private float playerSpeed = 6;
        [SerializeField] private int jumpPower = 400;
        [SerializeField] private bool isGrounded;

        private float moveX;

        public int JumpPower => jumpPower;

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
            playerRigidbody.AddForce(Vector2.up * jumpPower);
        }

        private void CheckDeath()
        {
            //TODO: Refactor checking of death
            if (gameObject.transform.position.y < -7)
            {
                MainDependency.GetInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService()
                    .OpenProgressBar();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer == Layers.GROUND_LAYER && isGrounded)
            {
                isGrounded = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == Layers.GROUND_LAYER)
            {
                isGrounded = true;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.layer == Layers.GROUND_LAYER)
            {
                isGrounded = true;
            }
        }
    }
}