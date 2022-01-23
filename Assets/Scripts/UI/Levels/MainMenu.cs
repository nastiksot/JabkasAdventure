using Modules.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Levels
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Buttons")] [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
  
        private ISceneService sceneService;

        [Inject]
        public void Construct(ISceneService sceneService)
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
            playButton.onClick.AddListener(() => { sceneService.LoadSceneAsync("IntroLevel"); });
#if PLATFORM_ANDROID
            settingsButton.onClick.AddListener(Application.Quit);
#endif
        }
    }
}