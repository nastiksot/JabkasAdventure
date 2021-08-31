using System;
using DI;
using DI.Models;
using DI.Models.PlayerModel;
using DI.Services.Data.Interfaces;
using TMPro;
using UI.Base;
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

            pauseButton.onClick.AddListener(SubscribePauseMenu);

            dataService = MainDependency.GetInstance().GetServiceManager().GetDataService();
        }

        private void SubscribePauseMenu()
        {
            MainDependency.GetInstance().GetGameManager().GetPauseMenu(pauseMenu =>
            {
                var pauseMenuBackground = pauseMenu.Background;
                CanvasTool.State(ref pauseMenuBackground, true);
            }, error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        public void UpdatePlayerData(PlayerData data)
        {
            playerData = new PlayerData()
            {
                PlayerHealth = data.PlayerHealth,
                PlayerScore = data.PlayerScore,
                PlayerName = data.PlayerName
            };
        }

        public void SaveDataFile()
        {
            dataService.SaveData(playerData, filePath);
        }

        public void LoadDataFile(Action<PlayerData> playerData, Action<BaseError> failure)
        {
            dataService.LoadData(filePath, loadedData => { playerData?.Invoke(loadedData); },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        private void UpdateUIData()
        {
            LoadDataFile(data =>
                {
                    totalScore.text = data.PlayerScore.ToString();
                    sheetValue.text = data.SheetScore.ToString();
                },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        public void ChangeSheetScoreValue(int sheetCosts)
        {
            summarySheet++;

            summaryScore += sheetCosts;

            sheetValue.text = summarySheet.ToString();
            totalScore.text = (summaryScore).ToString();

            playerData.UpdateScore(summaryScore);
            playerData.UpdateSheetCount(summarySheet);
        }

        public void ChangeTotalScoreValueByKilledSpider(int killedEnemy)
        {
            summaryScore += killedEnemy;
            totalScore.text = (summaryScore).ToString();
        }
    }
}