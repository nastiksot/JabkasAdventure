using System;
using Models.ConstantValues;
using UnityEngine;

namespace UI.Levels.MarioGame.Books
{
    public class CVSheet : MonoBehaviour
    { 
        private Rigidbody2D rigidbody2D;
        
        public event Action OnPlayerCollided;
        
        private void Start()
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
            OnPlayerCollided?.Invoke();
        }
    }
}