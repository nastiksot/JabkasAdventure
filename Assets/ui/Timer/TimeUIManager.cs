using System;
using DI;
using TMPro;
using UI.Base;
using UI.Games.Menus;
using UI.Navigation;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Timer
{
    public class TimeUIManager : MonoBehaviour
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private CanvasGroup pauseButtonCanvasGroup;
        [SerializeField] private TMP_Text timeRemainText;

        private TimerController timerController = new TimerController();
        private NavigationMenu navigationMenu;
        private GameOverMenu gameOverMenu;


        public Button PauseButton => pauseButton;
        public CanvasGroup PauseButtonCanvasGroup => pauseButtonCanvasGroup;

        private void Start()
        {
            GetNavigationMenu();
            GetGameOverMenu();

            pauseButton.onClick.AddListener(() =>
            {
                timerController.PauseTimer();
                HideAll();
            });

            timerController.BeginTimer();
            timerController.OnTimeChanged += OnTimeChanged;
            timerController.OnTimeOver+=OnTimeOver;
        } 
 
        public void Update()
        {
            timerController.StartTimer();
        }
        
        /// <summary>
        /// Initialize game over canvas on time is over
        /// </summary>
        private void OnTimeOver()
        {
            gameOverMenu.PlayerDeath();
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
        /// Hide all canvas group
        /// </summary>
        private void HideAll()
        {
            navigationMenu.SetNavigationMenuVisibility(false);
            CanvasTool.State(ref pauseButtonCanvasGroup, false);
        }

        /// <summary>
        /// Unpause timer
        /// </summary>
        public void Unpause()
        {
            timerController.Unpause();
        }

        /// <summary>
        /// Pause timer
        /// </summary>
        public void Pause()
        {
            timerController.PauseTimer();
        }

        /// <summary>
        /// Set time manager ui visibility
        /// </summary>
        /// <param name="state"></param>
        public void SetTimerManagerUIVisibility(bool state)
        { 
            CanvasTool.State(ref pauseButtonCanvasGroup, state);
        }
        
        /// <summary>
        /// Get navigation menu
        /// </summary>
        private void GetNavigationMenu()
        {
            MainDependency.GetInstance().GetGameManager().GetNavigationMenu(menu => { navigationMenu = menu; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }
        
        /// <summary>
        /// Get game over menu
        /// </summary>
        private void GetGameOverMenu()
        {
            MainDependency.GetInstance().GetGameManager().GetGameOverMenu(menu => { gameOverMenu = menu; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }
         
    }
}