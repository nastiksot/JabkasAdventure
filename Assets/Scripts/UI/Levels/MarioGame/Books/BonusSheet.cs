using System;
using Models.ConstantValues;
using UnityEngine;

namespace UI.Levels.MarioGame.Books
{
    public class BonusSheet : MonoBehaviour
    { 
        private Rigidbody2D rigidbody2D;
        
        public event Action OnSheetCollided;
        
        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == Layers.GROUND_LAYER)
            {
                rigidbody2D.bodyType = RigidbodyType2D.Static;
            }

            if (!other.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            OnSheetCollided?.Invoke();
            Destroy(gameObject);
        }
    }
}