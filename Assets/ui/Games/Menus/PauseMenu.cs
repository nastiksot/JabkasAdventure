using System;
using DI;
using UI.Base;
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

        public CanvasGroup Background => background;
        public Button ContinueButton => continueButton;
        public Button ExitButton => exitButton;

        private void Start()
        {
            continueButton.onClick.AddListener(() =>
            {
                SubscribeNavigationMenu();
                SubscribeTimerManager();

                CanvasTool.State(ref background, false);
            });

            exitButton.onClick.AddListener(() =>
            {
                MainDependency.GetInstance().GetUIManager().GetNavigator().InitMainMenu();
            });
            
            CanvasTool.State(ref background, false);
        }

        private void SubscribeTimerManager()
        {
            MainDependency.GetInstance().GetGameManager().GetTimerManager(timerManager =>
            {
                var timerManagerCanvas = timerManager.PauseButtonCanvasGroup;
                CanvasTool.State(ref timerManagerCanvas, true);
                timerManager.Unpause();
            }, error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        private void SubscribeNavigationMenu()
        {
            MainDependency.GetInstance().GetGameManager().GetNavigationMenu(navigationMenu =>
            {
                var navigationMenuNavigationCanvas = navigationMenu.NavigationCanvas;
                CanvasTool.State(ref navigationMenuNavigationCanvas, true);
            }, error => { ToastUtility.ShowToast(error.errorMessage); });
        }
    }
}