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
        [SerializeField] private CanvasGroup canvasGroup;
        private float timeLeft;


        private IPauseMenuService pauseMenuService;
        private IStatisticService statisticService;
        private ITimer timer;
        public float TimeLeft => timeLeft;

        [Inject]
        private void Construct(ITimer timer, IStatisticService statisticService,
            IPauseMenuService pauseMenuService)
        {
            this.timer = timer;
            this.statisticService = statisticService;
            this.pauseMenuService = pauseMenuService;
        }


        private void Start()
        {
            pauseMenuService.OnPauseButtonPressed += timer.PauseTimer;
            pauseMenuService.OnContinueButtonPressed += timer.Unpause;
            pauseMenuService.OnExitButtonPressed += OnExitButtonPressed;

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
            timeLeft = seconds;
            timeRemainText.text = seconds.ToString();
        }

        private void OnExitButtonPressed()
        {
            timer.StopTimer();
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

        public void SetStatisticUIVisibility(bool state)
        {
            CanvasTool.State(ref canvasGroup, state);
        }
    }
}