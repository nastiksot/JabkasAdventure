using DI;
using TMPro;
using UI.Base;
using UI.DataSaver;
using UI.Timer;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Games.Menus
{
    public class GameOverMenu : BaseMono
    {
        [Header("Buttons")] [SerializeField] private Button retryButton;
        [SerializeField] private Button exitButton;

        [Header("Text")] [SerializeField] private TMP_Text scoreText;

        [Space(6f)] [SerializeField] private CanvasGroup background;


        private StatisticsDataCollector statisticsDataCollector;
        private TimeUIManager timeUIManager;

        public CanvasGroup Background => background;

        public string ScoreText
        {
            get => scoreText.text;
            set => scoreText.text = value;
        }

        private void Start()
        {
            retryButton.onClick.AddListener(() =>
            {
                timeUIManager.Unpause();
                MainDependency.GetInstance().GetUIManager().GetNavigator().StartLoadingScreen();
            });
            exitButton.onClick.AddListener(() =>
            {
                timeUIManager.Unpause();
                MainDependency.GetInstance().GetUIManager().GetNavigator().InitMainMenu();
            });
            GetStatistics();
            GetTimerManager();
            SetGameOverMenuVisibility(false);
        }

        /// <summary>
        /// Show game over UI on player death
        /// </summary>
        public void PlayerDeath()
        {
            SetGameOverMenuVisibility(true);
            ShowStatisticData();
            timeUIManager.Pause();
        }

        /// <summary>
        /// Set Game over menu visibility
        /// </summary>
        /// <param name="state"></param>
        public void SetGameOverMenuVisibility(bool state)
        {
            CanvasTool.State(ref background, state);
        }


        /// <summary>
        /// Save data to file and display statistics
        /// </summary>
        private void ShowStatisticData()
        {
            statisticsDataCollector.SaveDataFile();
            statisticsDataCollector.LoadDataFile(data => { scoreText.text = data.PlayerScore.ToString(); },
                error => { ToastUtility.ShowToast(error.errorMessage); });
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
    }
}