using System;
using Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Services
{
    public class PauseMenuService : MonoBehaviour, IPauseMenuService
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
                OnContinueButtonPressed?.Invoke();
                SetPauseMenuVisibility(false);
            });

            pauseButton.onClick.AddListener(() =>
            {
                OnPauseButtonPressed?.Invoke();
                SetPauseMenuVisibility(true);
            });

            exitButton.onClick.AddListener(() =>
            {
                OnExitButtonPressed?.Invoke();
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

    }
}