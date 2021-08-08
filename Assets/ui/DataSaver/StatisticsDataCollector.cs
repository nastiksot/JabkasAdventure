using System;
using DI;
using Models;
using Models.PlayerModel;
using Services.Data.Interfaces;
using TMPro;
using UI.Base;
using UnityEngine;

namespace UI.DataSaver
{
    public class StatisticsDataCollector : MonoBehaviour
    {
        [Header("Text")] [SerializeField] private TMP_Text totalScore;
        [SerializeField] private TMP_Text sheetValue;


        private static StatisticsDataCollector instance = new StatisticsDataCollector();
        private PlayerData playerData;
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

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            dataService = MainDependency.GetInstance().GetServiceManager().GetDataService();
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

        private void LoadDataFile(Action<PlayerData> playerData, Action<BaseError> failure)
        {
            dataService.LoadData(filePath, loadedData => { playerData?.Invoke(loadedData); },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        private void UpdateUIData()
        {
            LoadDataFile(data =>
            {
                totalScore.text = playerData.PlayerScore.ToString();
            }, error => { ToastUtility.ShowToast(error.errorMessage);});
        }

        public void ChangeSheetScoreValue(int sheetCosts)
        {
            summarySheet++;

            summaryScore += sheetCosts;

            sheetValue.text = summarySheet.ToString();
            totalScore.text = (summaryScore).ToString();
        }

        public void ChangeTotalScoreValueByKilledSpider(int killedEnemy)
        {
            summaryScore += killedEnemy;
            totalScore.text = (summaryScore).ToString();
        }
    }
}