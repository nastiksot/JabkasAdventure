using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.DataSaver
{
    public class StatisticsDataCollector : MonoBehaviour
    {
        [Header("Text")] [SerializeField] private TMP_Text totalScore;
        [SerializeField] private TMP_Text sheetValue;


        private static StatisticsDataCollector instance = new StatisticsDataCollector();
        private PlayerData playerData;

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
        }

        public void OnDataChanged(PlayerData data)
        {
            playerData = new PlayerData()
            {
                PlayerHealth = data.PlayerHealth,
                PlayerScore = data.PlayerScore,
                PlayerName = data.PlayerName
            };
        }

        public void CreateSaveDataFile()
        {
            SaveDataManager.SaveData(playerData, filePath);
        }

        public PlayerData LoadDataFile()
        {
            return SaveDataManager.LoadData(filePath);
        }

        public void UpdateLoadedUI()
        {
            var loadData = LoadDataFile();
            sheetValue.text = loadData.PlayerScore.ToString();
        }

        public void ChangeSheetScoreValue(int sheetCosts)
        {

            summarySheet++;
            
            summaryScore +=  sheetCosts;
            
            sheetValue.text = summarySheet.ToString();
            totalScore.text = (summaryScore).ToString();
        }

        public void ChangeTotalScoreValueByKilledSpider(int killedEnemy)
        {
            summaryScore += killedEnemy ;
            totalScore.text = (summaryScore).ToString();
        }
        
    }
}