using System;
using DI;
using DI.Services.Constants;
using Standard_Assets.CrossPlatformInput.Scripts;
using UI.Base;
using UnityEngine;

namespace UI.Player
{
    [Flags]
    public enum DeprecateDirection
    {
        None = 0,
        Left = 1,
        Right = 2,
        One = Right | Left
    }

    public class PlayerBehaviour : BaseMono
    {
        [SerializeField] private SpriteRenderer playerSprite;
        [SerializeField] private Rigidbody2D playerRigidbody;

        [Space(6f)] [SerializeField] private float playerSpeed = 6;
        [SerializeField] private int jumpPower = 400;
        [SerializeField] private bool isGrounded;
        [SerializeField] private float rayDistance;
        [SerializeField] private Transform rayTransform;

        private float moveX;
        private bool facingDirection = true; //true = right | false = left
        private DeprecateDirection deprecateDirection = DeprecateDirection.None;

        private void FixedUpdate()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            var wallRaycast = rayDistance;

            if (facingDirection == false)
            {
                wallRaycast = -rayDistance;
            }

            var targetPos = rayTransform.position;
            targetPos.x += wallRaycast;

            Debug.DrawLine(transform.position, targetPos, Color.blue);
            if (Physics2D.Linecast(transform.position, targetPos, 1 << LayerMask.NameToLayer(Layers.GROUND_LAYER_NAME)))
            {
                deprecateDirection = targetPos.x > 0 ? DeprecateDirection.Right : DeprecateDirection.Left;
                isGrounded = false;
            }
            else
            {
                deprecateDirection = DeprecateDirection.None;
            }

            //controllers and directions
            moveX = CrossPlatformInputManager.GetAxis("Horizontal");
            if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded &&
                deprecateDirection != DeprecateDirection.One)
            {
                Jump();
            }

            if (moveX < 0.0f)
            {
                facingDirection = false;
                transform.localScale = new Vector3(-1, 1.1f, 0);
            }
            else if (moveX > 0.0f && deprecateDirection != DeprecateDirection.Right)
            {
                facingDirection = true;
                transform.localScale = new Vector3(1, 1.1f, 0);
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

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.layer == Layers.GROUND_LAYER && !isGrounded)
            {
                isGrounded = true;
            }
        }
    }
}