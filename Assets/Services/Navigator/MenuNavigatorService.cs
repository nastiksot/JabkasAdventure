using DI;
using Services.Navigator.interfaces;
using UI.Base;
using UnityEngine;

namespace Services.Navigator
{
    public class MenuNavigatorService : IMenuNavigatorService
    {
        private IMainNavigatorServices getMainNavigation()
        {
            return MainDependency.GetInstance().GetServiceManager().GetMainNavigatorService();
        }

        public void OpenMainMenu()
        {
            getMainNavigation().CloseAll();
            var mainMenu = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.MAIN_MENU));
            getMainNavigation().AddActionForClose(() => BaseMono.Destroy(mainMenu));
        }

        public void OpenIntroLevel()
        {
            getMainNavigation().CloseAll();
            var introGame = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.INTRO_GAME_LEVEL));
            var controllers = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.CONTROLS));
            var player = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.PLAYER));
            getMainNavigation().AddActionForClose(() =>
            {
                BaseMono.Destroy(introGame);
                BaseMono.Destroy(controllers);
                BaseMono.Destroy(player);
            });
        }

        public void OpenMarioLevel()
        {
            getMainNavigation().CloseAll();
            var marioGame = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.MARIO_GAME_LEVEL)); 
            getMainNavigation().AddActionForClose(() =>
            {
                BaseMono.Destroy(marioGame); 
            }); 
        }
        public void OpenProgressBar()
        {
            getMainNavigation().CloseAll();
            var progressBar = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.PROGRESS_BAR));
       
            getMainNavigation().AddActionForClose(() =>
            {
                BaseMono.Destroy(progressBar); 
            });
        }
    }
}