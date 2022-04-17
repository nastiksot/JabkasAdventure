using Models.Enum;
using Services.Interfaces;
using TMPro;
using UI.Player.Interfaces;
using UI.Timer;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Zenject;

namespace UI
{
    public class GameOverMenu : MonoBehaviour
    {
        [Header("Buttons")] [SerializeField] private Button retryButton;
        [SerializeField] private Button exitButton;

        [Header("Text")] [SerializeField] private TMP_Text scoreText;

        [Space(6f)] [SerializeField] private CanvasGroup gameOverCanvasGroup;

        private ButtonUIInput buttonUIInput;
        private ISceneService sceneService;
        private IPlayerBehaviour playerBehaviour;
        private IPauseMenuService pauseMenuService;
        private ITimer timer;

        [Inject]
        private void Construct(ISceneService sceneService, IPlayerBehaviour playerBehaviour,
            ButtonUIInput buttonUIInput, IPauseMenuService pauseMenuService, ITimer timer)
        {
            this.sceneService = sceneService;
            this.playerBehaviour = playerBehaviour;
            this.buttonUIInput = buttonUIInput;
            this.pauseMenuService = pauseMenuService;
            this.timer = timer;
        }

        private void OnEnable()
        {
            playerBehaviour.OnPlayerDeath += ShowGameOverMenu;
            timer.OnTimeOver += ShowGameOverMenu;
        }

        private void OnDisable()
        {
            playerBehaviour.OnPlayerDeath -= ShowGameOverMenu;
            timer.OnTimeOver -= ShowGameOverMenu;
        }

        private void Start()
        {
            SubscribeOnRetryButton();
            SubscribeOnExitButton();
            SetGameOverMenuVisibility(false);
        }

        private void SubscribeOnExitButton()
        {
            exitButton.onClick.AddListener(() => { StartCoroutine(sceneService.LoadSceneAsync(SceneType.Menu)); });
        }

        private void SubscribeOnRetryButton()
        {
            retryButton.onClick.AddListener(() =>
            {
                var restartScene = sceneService.CurrentScene;
                StartCoroutine(sceneService.LoadSceneAsync(restartScene));
            });
        }

        /// <summary>
        /// Show game over canvas
        /// </summary>
        private void ShowGameOverMenu()
        {
            gameOverCanvasGroup.State(true);
            buttonUIInput.SetButtonInputVisibility(false);
            pauseMenuService.SetPauseButtonState(false);
            timer.PauseTimer();
        }

        /// <summary>
        /// Set Game over menu visibility
        /// </summary>
        /// <param name="state"></param>
        private void SetGameOverMenuVisibility(bool state)
        {
            gameOverCanvasGroup.State(state);
        }

        /// <summary>
        /// Save data to file and display statistics
        /// </summary>
        private void ShowStatisticData()
        {
        }
    }
}