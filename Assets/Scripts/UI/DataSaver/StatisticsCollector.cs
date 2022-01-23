using System;
using System.Linq;
using Models;
using Models.ClassModels;
using Models.Enum;
using Models.ScriptableObjects;
using Services.Interfaces;
using TMPro;
using UI.Timer;
using UnityEngine;
using Utility;
using Zenject;

namespace UI.DataSaver
{
    public class StatisticsCollector : MonoBehaviour
    {
        [Header("Text")] [SerializeField] private TMP_Text totalScore;
        [SerializeField] private TMP_Text sheetValue;
        [SerializeField] private TMP_Text timeRemainText;

        [SerializeField] private CanvasGroup statisticDataCanvasGroup;
        [SerializeField] private BonusCostSO bonusCost;
        
        private int summarySheet;
        private int summaryScore;

        private string filePath = "DefaultSave";
        private PlayerData playerData;

        private IDataService dataService;
        private ITimer timer;

        public string FilePath
        {
            get => filePath;
            set => filePath = value;
        } 

        
        [Inject]
        public void Construct(ITimer timer, IDataService dataService)
        {
            this.timer = timer;
            this.dataService = dataService;
        }

      
        private void Start()
        {
            timer.BeginTimer();
            timer.OnTimeChanged += OnTimeChanged;
        }

        public void Update()
        {
            timer.UpdateTimer();
        }

        /// <summary>
        /// Set timer value on UI 
        /// </summary>
        /// <param name="seconds"></param>
        private void OnTimeChanged(float seconds)
        {
            timeRemainText.text = seconds.ToString();
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
        public void ChangeScore(BonusType bonusType)
        {
            var scoreValue = bonusCost.BonusCosts.FirstOrDefault(x => x.key == bonusType)?.value;
            if (scoreValue == null) return;
            switch (bonusType)
            {
                case BonusType.Sheet:
                    summarySheet++;
                    sheetValue.text = summarySheet.ToString();
                    playerData.UpdateSheetCount(summarySheet);
                    break;
                case BonusType.Spider: 
                    break;
            }

            summaryScore += (int)scoreValue; 
            playerData.UpdateScore(summaryScore); 
            totalScore.text = (summaryScore).ToString();
  
        } 
    }
}