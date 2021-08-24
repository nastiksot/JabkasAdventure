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
        [SerializeField] private TimerManager timerManager;
        [SerializeField] private CanvasGroup background;
        
        [Header("Buttons")]
        [SerializeField] private Button continueButton;
        [SerializeField] private Button exitButton;

        private void Start()
        {
            timerManager = FindObjectOfType<TimerManager>();
            if (timerManager == null) return;
            continueButton.onClick.AddListener(() =>
            {
                timerManager.PauseButton.gameObject.SetActive(true);
                SetCanvasVisibility(false);
                timerManager.Unpause();
            });

            exitButton.onClick.AddListener(() =>
            {
                MainDependency.GetInstance().GetUIManager().GetNavigator().InitMainMenu();
            });
            SetCanvasVisibility(false);
        }

        private void SetCanvasVisibility(bool state)
        {
            CanvasTool.State(ref background, state);
        }
    }
}