using DI;
using Services.Constants;
using UI.Base;
using UnityEngine;

namespace UI.Player
{
    public class TeleportCollision : BaseMono
    {
        private TeleportCollision()
        {
            TAG = "TeleportCollision";
        }


        private void OnTriggerEnter2D
            (Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            dlog("Collited and destroyed!");
            //GetComponent<AudioSource>().Play();
            MainDependency.GetInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenMarioLevel();
        }
    }
}