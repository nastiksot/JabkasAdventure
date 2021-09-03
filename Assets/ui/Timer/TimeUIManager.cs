using System;
using DI;
using TMPro;
using UI.Base;
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


        public Button PauseButton => pauseButton;
        public CanvasGroup PauseButtonCanvasGroup => pauseButtonCanvasGroup;

        private void Start()
        {
            GetNavigationMenu();
            pauseButton.onClick.AddListener(() =>
            {
                timerController.PauseTimer();
                HideAll();
            });

            timerController.BeginTimer();
            timerController.OnTimeChanged += OnTimeChanged;
        }

        private void OnTimeChanged(float seconds)
        {
            timeRemainText.text = seconds.ToString();
        }

        public void Update()
        {
            timerController.StartTimer();
        }

        private void HideAll()
        {
            var navigationMenuNavigationCanvas = navigationMenu.NavigationCanvas;
            CanvasTool.State(ref navigationMenuNavigationCanvas, false);
            CanvasTool.State(ref pauseButtonCanvasGroup, false);
        }

        public void Unpause()
        {
            timerController.Unpause();
        }

        public void Pause()
        {
            timerController.PauseTimer();
        }

        private void GetNavigationMenu()
        {
            MainDependency.GetInstance().GetGameManager().GetNavigationMenu(menu => { navigationMenu = menu; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }
    }
}