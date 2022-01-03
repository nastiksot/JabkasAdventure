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
  
        private ISceneLoader sceneLoader;

        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
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
            playButton.onClick.AddListener(() => { sceneLoader.LoadSceneAsync("IntroLevel"); });
#if PLATFORM_ANDROID
            settingsButton.onClick.AddListener(Application.Quit);
#endif
        }
    }
}