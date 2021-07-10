using UI.Base;
using UI.Games.mainMenu.interfaces;
using UI.Games.mainMenu.scripts;
using UnityEngine;

namespace UI.Games.mainMenu
{
    public class MainMenu : BaseMono, interfaces.MainMenu
    {
        [SerializeField] private ClickButtonImpl playButton;
        [SerializeField] private ClickButtonImpl settingsButton;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            playButton.setOnClickListener(() =>
            {
                MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService()
                    .GetMenuNavigatorService().OpenIntroLevel();
            });
#if PLATFORM_ANDROID
            settingsButton.setOnClickListener(Application.Quit);
#endif
        }
    }
}