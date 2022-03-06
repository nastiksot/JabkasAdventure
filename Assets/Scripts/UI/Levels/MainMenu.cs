using Models.Enum;
using Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Levels
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Buttons")] 
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private SceneType nextSceneType;
        
        
        private ISceneService sceneService;

        [Inject]
        private void Construct(ISceneService sceneService)
        {
            this.sceneService = sceneService;
        }

        private void Start()
        {
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
#if PLATFORM_ANDROID
            settingsButton.onClick.AddListener(Application.Quit);
#endif
        }
    }
}