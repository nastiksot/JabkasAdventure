using System.Collections;
using Models;
using Modules.Interfaces;
using UI.Base;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D playerRigidbody;

        [Header("Player Settings"), Space(6f)] 
        [SerializeField] private float speedMultiplier;
        [SerializeField] private int jumpPower;

        [Header("Raycast Settings"), Space(3f)]
        [SerializeField] private float rayHorizontalDistance;
        [SerializeField] private float rayVerticalDistance;
        [SerializeField] private Transform rayTransform;

        private bool isGrounded;
        private float moveX;
        private Coroutine moveCoroutine;
        
        private MovingDirection facingDirection = MovingDirection.Right;
        private DeprecateDirection deprecateDirection = DeprecateDirection.None;

        private IInputService inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            this.inputService = inputService;
        }

        private void Awake()
        {
            inputService.OnJump += Jump;
            inputService.OnMoveStarted += Move;
            inputService.OnMoveStopped += Stop;
        }

        private void Stop()
        {
            StopCoroutine(moveCoroutine);
        }

        private void Move(float movePosition)
        {
            playerRigidbody.angularVelocity = 0f;
            playerRigidbody.inertia = 0f;
            playerRigidbody.velocity = Vector2.zero;
            moveCoroutine = StartCoroutine(MoveCoroutine(movePosition));
        }

        private IEnumerator MoveCoroutine(float movePosition)
        {
            while (true)
            {
                moveX = movePosition;
                var wallRaycast = rayHorizontalDistance;

                if (facingDirection == MovingDirection.Left)
                {
                    wallRaycast = -rayHorizontalDistance;
                }

                var rayCenterPosition = rayTransform.position;
                var targetPos = rayCenterPosition;
                targetPos.x += wallRaycast;
 
                if (Physics2D.Linecast(transform.position, targetPos, 1 << LayerMask.NameToLayer(Layers.GROUND_LAYER_NAME)))
                {
                    deprecateDirection = targetPos.x > 0 ? DeprecateDirection.Right : DeprecateDirection.Left;
                    isGrounded = false;
                    StopCoroutine(moveCoroutine);
                    yield break;
                }

                deprecateDirection = DeprecateDirection.None;

                if (moveX < 0.0f && !deprecateDirection.HasFlag(DeprecateDirection.Left))
                {
                    facingDirection = MovingDirection.Left;
                    transform.localScale = new Vector3(-1, 1.1f, 0);
                }
                else if (moveX > 0.0f && !deprecateDirection.HasFlag(DeprecateDirection.Right))
                {
                    facingDirection = MovingDirection.Right;
                    transform.localScale = new Vector3(1, 1.1f, 0);
                }

                var transformPosition = playerRigidbody.transform.position;
                transformPosition.x = transform.position.x+ moveX*speedMultiplier;
                transform.position = transformPosition;
                
                yield return null;
            }
        }


        private void Jump()
        {
            var rayCenterPosition = rayTransform.position;
            var groundPos = new Vector2(rayCenterPosition.x, (rayCenterPosition.y - rayVerticalDistance)); 
            isGrounded = Physics2D.Linecast(transform.position, groundPos, 1 << LayerMask.NameToLayer(Layers.GROUND_LAYER_NAME));
            if (!isGrounded) return;
            playerRigidbody.AddForce(Vector2.up * jumpPower);
        }
    }
}