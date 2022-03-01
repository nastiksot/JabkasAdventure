using System;
using Models.ConstantValues;
using UnityEngine;

namespace UI.Levels.MarioGame.Books
{
    public class LibraryBook : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer blockSprite;
        [SerializeField] private Sprite emptyShelfSprite;

        private bool isContainSheet = true;
        private float hitOffset = 0.3f;
        private Vector3 blockPosition;

        public event Action<Vector3> OnBlockCollided;

        private void Awake()
        {
            blockPosition = transform.position;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG) || !isContainSheet ||
                !(col.collider.bounds.max.y < transform.position.y) ||
                !(col.collider.bounds.min.x < transform.position.x + hitOffset) ||
                !(col.collider.bounds.min.x < transform.position.x - hitOffset)) return;
            //TODO: init sound hit block; 
            blockSprite.sprite = emptyShelfSprite;
            isContainSheet = false;
            OnBlockCollided?.Invoke(blockPosition);
        }
    }
}