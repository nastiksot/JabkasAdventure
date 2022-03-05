using System;
using Models.ClassModels;
using Models.Enum;
using Services.Interfaces;
using TMPro;
using UI.Timer;
using UnityEngine;
using Utility;
using Zenject;

namespace UI.DataSaver
{
    public class UIStatistic : MonoBehaviour
    {
        [Header("Text")] [SerializeField] private TMP_Text totalScoreText;
        [SerializeField] private TMP_Text sheetValueText;
        [SerializeField] private TMP_Text timeRemainText;

        [SerializeField] private CanvasGroup statisticDataCanvasGroup;

        private string filePath = "DefaultSave";

        private IFileService fileService;
        private IPauseMenuService pauseMenuService;
        private IStatisticService statisticService;
        private IRewardService rewardService;
        private ITimer timer;

        [Inject]
        private void Construct(ITimer timer, IFileService fileService, IStatisticService statisticService,
            IPauseMenuService pauseMenuService, IRewardService rewardService)
        {
            this.timer = timer;
            this.fileService = fileService;
            this.statisticService = statisticService;
            this.pauseMenuService = pauseMenuService;
            this.rewardService = rewardService;
        }


        private void Start()
        {
            pauseMenuService.OnPauseButtonPressed += timer.PauseTimer;
            pauseMenuService.OnContinueButtonPressed += timer.Unpause;
            pauseMenuService.OnExitButtonPressed += timer.StopTimer;
            
            statisticService.OnScoreChanged += OnTotalScoreChanged;
            statisticService.OnSheetAdded += OnSheetNumberChanged;
            
            timer.OnTimeChanged += OnTimeChanged;
            timer.BeginTimer();
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
        /// Set sheet number on UI 
        /// </summary>
        /// <param name="sheetNumber"></param>
        private void OnSheetNumberChanged(int sheetNumber)
        {
            sheetValueText.text = sheetNumber.ToString();
        }

        /// <summary>
        /// Set timer value on UI 
        /// </summary>
        /// <param name="totalScore"></param>
        private void OnTotalScoreChanged(int totalScore)
        {
            totalScoreText.text = totalScore.ToString();
        }

        /// <summary>
        /// Save data to file
        /// </summary>
        public void SaveFileData()
        {
            fileService.SaveData(statisticService.GetStatisticModel(), filePath);
        }

        /// <summary>
        /// Load data from file
        /// </summary>
        /// <param name="playerData"></param>
        /// <param name="failure"></param>
        public void LoadFileData(Action<StatisticModel> playerData, Action<BaseError> failure)
        {
            fileService.LoadData(filePath, loadedData => { playerData?.Invoke(loadedData); },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        /// <summary>
        /// Update data on UI
        /// </summary>
        private void LoadUIFileData()
        {
            LoadFileData(data =>
                {
                    totalScoreText.text = data.Score.ToString();
                    sheetValueText.text = data.SheetCount.ToString();
                },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }
    }
}