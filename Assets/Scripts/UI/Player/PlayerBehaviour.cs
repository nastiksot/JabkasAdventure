using Standard_Assets.CrossPlatformInput.Scripts;
using UI.Base;
using UnityEngine;

namespace UI.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer playerSprite;
        [SerializeField] private Rigidbody2D playerRigidbody;

        [Space(6f)] [SerializeField] private float playerSpeed = 6;
        [SerializeField] private int jumpPower = 400;
        [SerializeField] private bool isGrounded;
        [SerializeField] private float rayHorizontalDistance;
        [SerializeField] private float rayVerticalDistance;
        [SerializeField] private Transform rayTransform;

        private float moveX;
        private bool facingDirection = true; //true = right | false = left
        [SerializeField] private DeprecateDirection deprecateDirection = DeprecateDirection.None;

        private void FixedUpdate()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            var wallRaycast = rayHorizontalDistance;

            if (facingDirection == false)
            {
                wallRaycast = -rayHorizontalDistance;
            }

            var rayCenterPosition = rayTransform.position;
            var targetPos = rayCenterPosition;
            targetPos.x += wallRaycast;

            var groundPos = new Vector2(rayCenterPosition.x, (rayCenterPosition.y -rayVerticalDistance));

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
            
            Debug.DrawLine(transform.position, groundPos, Color.blue);
            isGrounded = Physics2D.Linecast(transform.position, groundPos, 1 << LayerMask.NameToLayer(Layers.GROUND_LAYER_NAME));

            moveX = CrossPlatformInputManager.GetAxis("Horizontal");
            if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }

            if (moveX < 0.0f)
            {
                facingDirection = false;
                transform.localScale = new Vector3(-1, 1.1f, 0);
            }
            else if (moveX > 0.0f && !deprecateDirection.HasFlag(DeprecateDirection.Right))
            {
                facingDirection = true;
                transform.localScale = new Vector3(1, 1.1f, 0);
            } 

            playerRigidbody.velocity =
                new Vector2(moveX * playerSpeed, playerRigidbody.velocity.y);
        }

        private void Jump()
        {
            playerRigidbody.AddForce(Vector2.up * jumpPower);
        }
 
    }
}