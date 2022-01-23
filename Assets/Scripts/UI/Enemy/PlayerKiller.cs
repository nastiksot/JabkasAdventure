using Models;
using Models.ConstantValues;
using UnityEngine; 

namespace UI.Enemy
{
    public class PlayerKiller : MonoBehaviour
    {
        private GameOverMenu gameOverMenu;
  
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            gameOverMenu.PlayerDeath();
            Destroy(other.gameObject);
        }

 
    }
}