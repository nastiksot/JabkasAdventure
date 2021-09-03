using System;
using DI;
using DI.Services.Constants;
using UI.Base;
using UI.DataSaver;
using UI.Games.Menus;
using UnityEngine;

namespace UI.Games.MarioGame
{
    public class DeadLine : BaseMono
    {
        private GameOverMenu gameOverMenu;
        private StatisticsDataCollector statisticsDataCollector;

        private void Start()
        {
            GetGameOverMenu();
            GetStatistics();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER_TAG)) return;
            SetGameOverMenuVisibility(true);
            ShowStatisticData();
        }

        private void ShowStatisticData()
        {
            statisticsDataCollector.SaveDataFile();
            statisticsDataCollector.LoadDataFile(data => { gameOverMenu.ScoreText = data.PlayerScore.ToString(); },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        private void SetGameOverMenuVisibility(bool state)
        {
            var menuBackground = gameOverMenu.Background;
            CanvasTool.State(ref menuBackground, state);
        }

        private void GetStatistics()
        {
            MainDependency.GetInstance().GetGameManager().GetStatisticsData(
                collector => { statisticsDataCollector = collector; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        private void GetGameOverMenu()
        {
            MainDependency.GetInstance().GetGameManager().GetGameOverMenu(menu => { gameOverMenu = menu; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }
    }
}