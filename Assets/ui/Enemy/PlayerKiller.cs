using System;
using DI;
using DI.Services.Constants;
using UI.Base;
using UI.DataSaver;
using UI.Games.Menus;
using UI.Timer;
using UnityEngine;

namespace UI.Enemy
{
    public class PlayerKiller : MonoBehaviour
    {
        private GameOverMenu gameOverMenu;

        private void Start()
        {
            GetGameOverMenu();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            gameOverMenu.PlayerDeath();
            Destroy(other.gameObject);
        }


        /// <summary>
        /// Get game over menu script
        /// </summary>
        private void GetGameOverMenu()
        {
            MainDependency.GetInstance().GetGameManager().GetGameOverMenu(menu => { gameOverMenu = menu; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }
    }
}