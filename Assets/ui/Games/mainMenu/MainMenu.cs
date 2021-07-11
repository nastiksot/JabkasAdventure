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

        public void Init()
        {
            playButton.onClick.AddListener(() =>
            {
                MainDependency.getInstance().GetServiceManager().GetMainNavigatorService()
                    .GetMenuNavigatorService().OpenIntroLevel();
            });
#if PLATFORM_ANDROID
            settingsButton.onClick.AddListener(Application.Quit);
#endif
        }
    }
} 