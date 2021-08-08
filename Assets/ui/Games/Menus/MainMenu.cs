using DI;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Games.mainMenu
{
    public class MainMenu : BaseMono
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            playButton.onClick.AddListener(() =>
            {
                MainDependency.GetInstance().GetUIManager().GetNavigator().StartIntroLevel();
            });
#if PLATFORM_ANDROID
            settingsButton.onClick.AddListener(Application.Quit);
#endif
        }
    }
} 