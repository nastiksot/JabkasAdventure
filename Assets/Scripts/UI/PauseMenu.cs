using System;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private CanvasGroup background;
        [SerializeField] private CanvasGroup pauseButtonCanvas;

        [Header("Buttons")] [SerializeField] private Button continueButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button exitButton;

        public event Action OnContinueButtonPressed;
        public event Action OnPauseButtonPressed;
        public event Action OnExitButtonPressed;


        private void Start()
        {
            SetPauseMenuVisibility(false);

            continueButton.onClick.AddListener(() =>
            {
                // timeUIManager.Unpause();
                // timeUIManager.SetTimerManagerUIVisibility(true);
                // navigationMenu.SetNavigationMenuVisibility(true);

                OnContinueButtonPressed?.Invoke();
                SetPauseMenuVisibility(false);
                SetPause(false);
            });

            pauseButton.onClick.AddListener(() =>
            {
                OnPauseButtonPressed?.Invoke();
                SetPauseMenuVisibility(true);
                SetPause(true);
            });

            exitButton.onClick.AddListener(() =>
            {
                // timeUIManager.Unpause();
                // MainDependency.GetInstance().GetUIManager().GetNavigator().InitMainMenu();
                OnExitButtonPressed?.Invoke();
                SetPause(false);
            });
        }

        /// <summary>
        /// Set pause menu visibility
        /// </summary>
        /// <param name="state"></param>
        private void SetPauseMenuVisibility(bool state)
        {
            background.State(state);
            pauseButtonCanvas.State(!state);
        }

        private void SetPause(bool state)
        {
            Time.timeScale = state ? 0f : 1f;
        }
    }
}