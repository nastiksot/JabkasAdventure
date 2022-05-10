using Disablers;
using Models.Enum;
using Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Zenject;

namespace UI.Levels
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Buttons")] 
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private CanvasSwitcher canvasSwitcher;
        [SerializeField] private CanvasDisabler canvasDisabler;
        [SerializeField] private SceneType nextSceneType;
        
        private ISceneService sceneService;
        private IAudioService audioService;
        
        [Inject]
        private void Construct(ISceneService sceneService, IAudioService audioService)
        {
            this.sceneService = sceneService;
            this.audioService = audioService;
        }

        private void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }
        
        private void Start()
        {
            // audioService.PlayAudio(sceneService.CurrentScene);
            InitGame();
        }

        /// <summary>
        /// Initialize Intro level
        /// </summary>
        private void InitGame()
        {
            playButton.onClick.AddListener(() =>
            {
                StartCoroutine(sceneService.LoadSceneAsync(nextSceneType));
            });
            
            settingsButton.onClick.AddListener(() =>
            {
                canvasSwitcher.DelayedOpenTable(canvasDisabler);
            });
            
#if PLATFORM_ANDROID
            quitButton.onClick.AddListener(Application.Quit);
#endif
        }
    }
}