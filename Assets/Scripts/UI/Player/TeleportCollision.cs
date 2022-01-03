using UI.Base;
using UnityEngine;

namespace UI.Player
{
    public class TeleportCollision : MonoBehaviour
    {  
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return; 
            //GetComponent<AudioSource>().Play();
            // MainDependency.GetInstance().GetUIManager().GetNavigator().StartLoadingScreen();
        }
    }
}