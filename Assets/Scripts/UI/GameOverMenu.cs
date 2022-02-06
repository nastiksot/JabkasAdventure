using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class GameOverMenu : MonoBehaviour
    {
        [Header("Buttons")] [SerializeField] private Button retryButton;
        [SerializeField] private Button exitButton;

        [Header("Text")] [SerializeField] private TMP_Text scoreText;

        [Space(6f)] [SerializeField] private CanvasGroup background;


        // private StatisticsDataCollector statisticsDataCollector;

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
                // timeUIManager.Unpause();
                // MainDependency.GetInstance().GetUIManager().GetNavigator().StartLoadingScreen();
            });
            exitButton.onClick.AddListener(() =>
            {
                // timeUIManager.Unpause();
                // MainDependency.GetInstance().GetUIManager().GetNavigator().InitMainMenu();
            });
            SetGameOverMenuVisibility(false);
        }

        /// <summary>
        /// Show game over UI on player death
        /// </summary>
        public void PlayerDeath()
        {
            SetGameOverMenuVisibility(true);
            ShowStatisticData();
            // timeUIManager.Pause();
        }

        /// <summary>
        /// Set Game over menu visibility
        /// </summary>
        /// <param name="state"></param>
        private void SetGameOverMenuVisibility(bool state)
        {
            background.State(state);
        }


        /// <summary>
        /// Save data to file and display statistics
        /// </summary>
        private void ShowStatisticData()
        {
            // statisticsDataCollector.SaveDataFile();
            // statisticsDataCollector.LoadDataFile(data => { scoreText.text = data.PlayerScore.ToString(); },
            //     error => { ToastUtility.ShowToast(error.errorMessage); });
        }
    }
}