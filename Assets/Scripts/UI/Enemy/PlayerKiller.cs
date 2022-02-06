using System;
using Models;
using Models.ConstantValues;
using UnityEngine; 

namespace UI.Enemy
{
    public class PlayerKiller : MonoBehaviour
    {
        public event Action OnPlayerCollision;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            OnPlayerCollision?.Invoke();
        }
    }
}