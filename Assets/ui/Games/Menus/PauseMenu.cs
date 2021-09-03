using System;
using DI;
using UI.Base;
using UI.Navigation;
using UI.Timer;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Games.Menus
{
    public class PauseMenu : BaseMono
    {
        [SerializeField] private CanvasGroup background;

        [Header("Buttons")] [SerializeField] private Button continueButton;
        [SerializeField] private Button exitButton;

        private TimeUIManager timeUIManager;
        private NavigationMenu navigationMenu;
        public CanvasGroup Background => background;
        public Button ContinueButton => continueButton;
        public Button ExitButton => exitButton;

        private void Start()
        {
            GetNavigationMenu();
            GetTimerManager();
            SetNavigationMenuVisibility(true);
            SetPauseMenuVisibility(false);

            continueButton.onClick.AddListener(() =>
            {
                timeUIManager.Unpause();
                SetTimerManagerUIVisibility(true);
                SetPauseMenuVisibility(false);
            });

            exitButton.onClick.AddListener(() =>
            {
                timeUIManager.Unpause();
                MainDependency.GetInstance().GetUIManager().GetNavigator().InitMainMenu();
            });
        }

        private void SetPauseMenuVisibility(bool state)
        {
            CanvasTool.State(ref background, state);
        }

        private void SetTimerManagerUIVisibility(bool state)
        {
            var timerManagerCanvas = timeUIManager.PauseButtonCanvasGroup;
            CanvasTool.State(ref timerManagerCanvas, state);
        }

        private void GetTimerManager()
        {
            MainDependency.GetInstance().GetGameManager().GetTimerManager(
                timerManager => { timeUIManager = timerManager; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        private void SetNavigationMenuVisibility(bool state)
        {
            var navigationMenuNavigationCanvas = navigationMenu.NavigationCanvas;
            CanvasTool.State(ref navigationMenuNavigationCanvas, state);
        }

        private void GetNavigationMenu()
        {
            MainDependency.GetInstance().GetGameManager().GetNavigationMenu(menu => { this.navigationMenu = menu; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }
    }
}