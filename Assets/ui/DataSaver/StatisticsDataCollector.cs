using System;
using DI;
using DI.Models;
using DI.Models.PlayerModel;
using DI.Services.Data.Interfaces;
using TMPro;
using UI.Base;
using UI.Games.Menus;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.DataSaver
{
    [DefaultExecutionOrder(1000)]
    public class StatisticsDataCollector : BaseMono
    {
        [Header("Text")] [SerializeField] private TMP_Text totalScore;
        [SerializeField] private TMP_Text sheetValue;

        [Header("Button")] [SerializeField] private Button pauseButton;

        private static StatisticsDataCollector instance = new StatisticsDataCollector();
        private PlayerData playerData = new PlayerData();
        private PauseMenu pauseMenu;
        private IDataService dataService;

        private string filePath = "DefaultSave";
        private int summarySheet;
        private int summaryScore;

        public static StatisticsDataCollector Instance
        {
            get => instance;
            set => instance = value;
        }

        public string FilePath
        {
            get => filePath;
            set => filePath = value;
        }

        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }

            dataService = MainDependency.GetInstance().GetServiceManager().GetDataService();

            GetPauseMenu();

            pauseButton.onClick.AddListener(() => { SetPauseMenuVisibility(true); });
        }

        /// <summary>
        /// Update player data 
        /// </summary>
        /// <param name="data"></param>
        public void UpdatePlayerData(PlayerData data)
        {
            playerData = new PlayerData()
            {
                PlayerHealth = data.PlayerHealth,
                PlayerScore = data.PlayerScore,
                PlayerName = data.PlayerName
            };
        }

        /// <summary>
        /// Save data to file
        /// </summary>
        public void SaveDataFile()
        {
            dataService.SaveData(playerData, filePath);
        }

        /// <summary>
        /// Load data from file
        /// </summary>
        /// <param name="playerData"></param>
        /// <param name="failure"></param>
        public void LoadDataFile(Action<PlayerData> playerData, Action<BaseError> failure)
        {
            dataService.LoadData(filePath, loadedData => { playerData?.Invoke(loadedData); },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        /// <summary>
        /// Update data on UI
        /// </summary>
        private void UpdateUIData()
        {
            LoadDataFile(data =>
                {
                    totalScore.text = data.PlayerScore.ToString();
                    sheetValue.text = data.SheetScore.ToString();
                },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        /// <summary>
        /// Change sheet score value
        /// </summary>
        /// <param name="sheetCosts"></param>
        public void ChangeSheetScoreValue(int sheetCosts)
        {
            summarySheet++;

            summaryScore += sheetCosts;

            sheetValue.text = summarySheet.ToString();
            totalScore.text = (summaryScore).ToString();

            playerData.UpdateScore(summaryScore);
            playerData.UpdateSheetCount(summarySheet);
        }

        /// <summary>
        /// Change total score value
        /// </summary>
        /// <param name="scoreValue"></param>
        public void ChangeTotalScore(int scoreValue)
        {
            summaryScore += scoreValue;
            totalScore.text = (summaryScore).ToString();
        }

        /// <summary>
        /// Get pause menu
        /// </summary>
        private void GetPauseMenu()
        {
            MainDependency.GetInstance().GetGameManager().GetPauseMenu(menu => { pauseMenu = menu; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        /// <summary>
        /// Set pause menu visibility
        /// </summary>
        /// <param name="state"></param>
        private void SetPauseMenuVisibility(bool state)
        {
            var pauseMenuBackground = pauseMenu.Background;
            CanvasTool.State(ref pauseMenuBackground, state);
        }
    }
}