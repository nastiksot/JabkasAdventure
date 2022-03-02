using System;
using Models.ConstantValues;
using UnityEngine;

namespace UI.Levels.MarioGame.Books
{
    public class BonusSheet : MonoBehaviour
    { 
        private Rigidbody2D rigidbody2D;

        public event Action<BonusSheet> OnSheetCollided;
        
        private void OnTriggerEnter2D(Collider2D other)
        {   
            if (!other.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            OnSheetCollided?.Invoke(this);
            Destroy(gameObject);
        }
    }
}