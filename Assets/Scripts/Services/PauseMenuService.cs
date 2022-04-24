using System;
using Models.Enum;
using Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Zenject;

namespace Services
{
    public class PauseMenuService : MonoBehaviour, IPauseMenuService
    {
        [SerializeField] private CanvasGroup pauseMenuCanvasGroup;
        [SerializeField] private CanvasGroup pauseButtonCanvasGroup;

        [Header("Buttons")] [SerializeField] private Button continueButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button exitButton;

        public event Action OnContinueButtonPressed;
        public event Action OnPauseButtonPressed;
        public event Action OnExitButtonPressed;

        private ISceneService sceneService;

        [Inject]
        private void Construct(ISceneService sceneService)
        {
            this.sceneService = sceneService;
        }

        private void Start()
        {
            SetPauseMenuVisibility(false);

            continueButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1f;
                OnContinueButtonPressed?.Invoke();
                SetPauseMenuVisibility(false);
            });

            pauseButton.onClick.AddListener(() =>
            {
                Time.timeScale = 0f;
                OnPauseButtonPressed?.Invoke();
                SetPauseMenuVisibility(true);
            });

            exitButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1f;
                OnExitButtonPressed?.Invoke();
                StartCoroutine(sceneService.LoadSceneAsync(SceneType.Menu));
            });
        }

        /// <summary>
        /// Set pause menu visibility
        /// </summary>
        /// <param name="state"></param>
        private void SetPauseMenuVisibility(bool state)
        {
            pauseMenuCanvasGroup.State(state);
            SetPauseButtonState(!state);
        }

        public void SetPauseButtonState(bool state)
        {
            pauseButtonCanvasGroup.State(state);
        }
    }
}