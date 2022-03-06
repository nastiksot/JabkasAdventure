using System;
using System.Collections;
using Models.ConstantValues;
using Models.Enum;
using Services.Interfaces;
using UI.Player.Interfaces;
using UnityEngine;
using Zenject;

namespace UI.Player
{
    public class PlayerBehaviour : MonoBehaviour, IPlayerBehaviour
    {
        [Header("Player Settings"), Space(6f)] [SerializeField]
        private float speedMultiplier;

        [SerializeField] private float jumpPower;

        [Header("Raycast Settings"), Space(3f)] [SerializeField]
        private float rayHorizontalDistance;

        [SerializeField] private float rayVerticalDistance;
        [SerializeField] private Transform rayTransform;
        [SerializeField] private Stomper stomperPrefab;

        private Stomper instantiatedStomper;
        private Rigidbody2D playerRigidbody;

        private bool isGrounded;
        private float moveX;
        private Vector2 cachedScale;
        private Coroutine moveCoroutine;

        private MovingDirection facingDirection = MovingDirection.Right;
        private DeprecateDirection deprecateDirection = DeprecateDirection.None;

        private IInputService inputService;
        private DiContainer diContainer;

        public event Action<Vector3> OnPlayerMove;

        [Inject]
        private void Construct(IInputService inputService, DiContainer diContainer)
        {
            this.inputService = inputService;
            this.diContainer = diContainer;
        }

        private void Awake()
        {
            inputService.OnJump += Jump;
            inputService.OnMoveStarted += Move;
            inputService.OnMoveStopped += Stop;

            playerRigidbody = GetComponent<Rigidbody2D>();

            CacheScale();
        }

        public void InitializeStomper()
        {
            instantiatedStomper = Instantiate(stomperPrefab, Vector3.zero, Quaternion.identity, transform);
            instantiatedStomper.Initialize(playerRigidbody);
            diContainer.Inject(instantiatedStomper);
        }

        public Transform GetPlayerTransform()
        {
            return transform;
        }

        private void Stop()
        {
            if (moveCoroutine == null) return;
            StopCoroutine(moveCoroutine);
        }

        private void CacheScale()
        {
            cachedScale = transform.localScale;
        }

        private void Move(float movePosition)
        {
            moveCoroutine = StartCoroutine(MoveCoroutine(movePosition));
        }

        private IEnumerator MoveCoroutine(float movePosition)
        {
            while (true)
            {
                moveX = movePosition;
                deprecateDirection = DeprecateDirection.None;

                var scaleMultiplier = 0;
                if (moveX < 0.0f && !deprecateDirection.HasFlag(DeprecateDirection.Left))
                {
                    facingDirection = MovingDirection.Left;
                    scaleMultiplier = -1;
                }
                else if (moveX > 0.0f && !deprecateDirection.HasFlag(DeprecateDirection.Right))
                {
                    facingDirection = MovingDirection.Right;
                    scaleMultiplier = 1;
                }

                if (IsCollidedWithWall()) yield break;
                var playerTransform = transform;
                playerTransform.localScale = new Vector3(scaleMultiplier * cachedScale.x, cachedScale.y, 0);

                var transformPosition = playerTransform.position;
                transformPosition.x = playerTransform.position.x + moveX * speedMultiplier;
                playerTransform.position = transformPosition;
                OnPlayerMove?.Invoke(transformPosition);
                yield return null;
            }
        }

        private bool IsCollidedWithWall()
        {
            var wallRaycast = rayHorizontalDistance;

            if (facingDirection == MovingDirection.Left)
            {
                wallRaycast = -rayHorizontalDistance;
            }

            var rayCenterPosition = rayTransform.position;
            var targetPos = rayCenterPosition;
            targetPos.x += wallRaycast;
            Debug.DrawLine(transform.position, targetPos, Color.red);
            if (!Physics2D.Linecast(transform.position, targetPos,
                1 << LayerMask.NameToLayer(Layers.GROUND_LAYER_NAME))) return false;
            deprecateDirection = targetPos.x > 0 ? DeprecateDirection.Right : DeprecateDirection.Left;
            isGrounded = false;
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }

            return true;
        }

        private void Jump()
        {
            var rayCenterPosition = rayTransform.position;
            var groundPos = new Vector2(rayCenterPosition.x, (rayCenterPosition.y - rayVerticalDistance));
            isGrounded = Physics2D.Linecast(transform.position, groundPos,
                1 << LayerMask.NameToLayer(Layers.GROUND_LAYER_NAME));
            if (!isGrounded) return;
            playerRigidbody.velocity = (Vector2.up * jumpPower);
        }
    }
}