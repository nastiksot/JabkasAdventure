using Models.ConstantValues;
using UI.Player.Interfaces;
using UnityEngine; 

namespace UI.Enemy
{
    public class PlayerKiller : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            if(!other.gameObject.TryGetComponent<IPlayerBehaviour>(out var playerBehaviour)) return;
            playerBehaviour.PlayerDeath();
        }
    }
}