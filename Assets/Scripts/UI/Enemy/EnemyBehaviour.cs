using System;
using Models.ConstantValues;
using Models.Enum;
using UI.Levels;
using UnityEngine;
using Zenject;

namespace UI.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float baseCastDist;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Transform raycastPosition;
        [SerializeField] private Rigidbody2D enemyRigidbody2D;
        [SerializeField] private RewardType rewardType;

        private bool facingDirection = true; //true = right | false = left
        private Vector3 baseScale;

        public RewardType RewardType => rewardType;
        
        public event Action OnEnemyDestroyed;

        private void Awake()
        {
            baseScale = transform.localScale;
        }

        private void FixedUpdate()
        {
            var velocityX = moveSpeed;
            if (facingDirection == false)
            {
                velocityX = -moveSpeed;
            }

            MoveEnemy(velocityX);

            if (IsHittingWall() || IsNearEdge())
            {
                ChangeFacingDirection(!facingDirection);
            }
        }

        public void DestroyEnemy()
        {
            OnEnemyDestroyed?.Invoke();
            Destroy(gameObject);
        }

        /// <summary>
        /// Move enemy
        /// </summary>
        /// <param name="velocityX"></param>
        private void MoveEnemy(float velocityX)
        {
            enemyRigidbody2D.velocity = new Vector2(velocityX, enemyRigidbody2D.velocity.y);
        }

        /// <summary>
        /// Check is enemy hitting wall
        /// </summary>
        /// <returns></returns>
        private bool IsHittingWall()
        {
            var isCollidedWall = false;

            var wallRaycast = baseCastDist;

            if (facingDirection == false)
            {
                wallRaycast = -baseCastDist;
            }

            var position = raycastPosition.position;
            var targetPos = position;

            targetPos.x += wallRaycast;


            Debug.DrawLine(position, targetPos, Color.magenta);
            if (Physics2D.Linecast(raycastPosition.position, targetPos,
                    1 << LayerMask.NameToLayer(Layers.GROUND_LAYER_NAME))
                || Physics2D.Linecast(raycastPosition.position, targetPos,
                    1 << LayerMask.NameToLayer(Layers.SWITCHER_LAYER_NAME)))
            {
                isCollidedWall = true;
            }

            return isCollidedWall;
        }

        /// <summary>
        /// Check is enemy near endge
        /// </summary>
        /// <returns></returns>
        private bool IsNearEdge()
        {
            var isCollidedEdge = true;

            var edgeRaycast = baseCastDist;

            var rayPosition = raycastPosition.position;
            var targetPos = rayPosition;

            targetPos.y -= edgeRaycast;

            Debug.DrawLine(rayPosition, targetPos, Color.blue);
            if (Physics2D.Linecast(raycastPosition.position, targetPos,
                    1 << LayerMask.NameToLayer(Layers.GROUND_LAYER_NAME))
                || Physics2D.Linecast(raycastPosition.position, targetPos,
                    1 << LayerMask.NameToLayer(Layers.SWITCHER_LAYER_NAME)))
            {
                isCollidedEdge = false;
            }

            return isCollidedEdge;
        }

        /// <summary>
        /// Change enemy direction
        /// </summary>
        /// <param name="newDirection"></param>
        private void ChangeFacingDirection(bool newDirection)
        {
            var newScale = baseScale;
            if (newDirection == false)
            {
                newScale.x = -baseScale.x;
            }

            transform.localScale = newScale;
            facingDirection = newDirection;
        }
    }
}