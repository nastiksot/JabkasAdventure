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
        private StatisticsDataCollector statisticsDataCollector;
        private TimeUIManager timeUIManager;

        private void Start()
        {
            GetGameOverMenu();
            GetStatistics();
            GetTimerManager();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            SetGameOverMenuVisibility(true);
            ShowStatisticData();
            timeUIManager.Pause();
            Destroy(other.gameObject);
        }  
        
        /// <summary>
        /// Save data to file and display statistics
        /// </summary>
        private void ShowStatisticData()
        {
            statisticsDataCollector.SaveDataFile();
            statisticsDataCollector.LoadDataFile(data => { gameOverMenu.ScoreText = data.PlayerScore.ToString(); },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        /// <summary>
        /// Set Game over menu visibility
        /// </summary>
        /// <param name="state"></param>
        private void SetGameOverMenuVisibility(bool state)
        {
            var menuBackground = gameOverMenu.Background;
            CanvasTool.State(ref menuBackground, state);
        }

        /// <summary>
        /// Get statistics data collector
        /// </summary>
        private void GetStatistics()
        {
            MainDependency.GetInstance().GetGameManager().GetStatisticsData(
                collector => { statisticsDataCollector = collector; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }
        
        /// <summary>
        /// Get time manager menu script
        /// </summary>
        private void GetTimerManager()
        {
            MainDependency.GetInstance().GetGameManager().GetTimerManager(
                timerManager => { timeUIManager = timerManager; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
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