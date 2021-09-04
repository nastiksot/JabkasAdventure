using DI.Interfaces;
using DI.Services.Navigator;
using DI.UI;
using UI.Base;
using UI.Games.GameManager;
using UI.Games.GameManager.Interfaces;

namespace DI
{
    public class MainDependency : BaseMono, IMainDependencys
    {
        private static IMainDependencys instance;
        private IServiceManager serviceManager;
        private IModuleManager moduleManager;
        private IUIManager uiManager;
        private IGameManager gameManager;
        private InteractorManager interactorManager;

        public void Start()
        {
            instance = this;

            gameManager = gameObject.AddComponent<GameManager>();
            moduleManager = new ModuleManager();
            uiManager = new UIManager();
            serviceManager = new ServiceManager(moduleManager);
            interactorManager = new InteractorManager(uiManager, gameManager);
        }

        public static IMainDependencys GetInstance()
        {
            if (instance == null)
            {
                instance = new MainDependency();
            }

            return instance;
        }

        /// <summary>
        /// Get UI manager
        /// </summary>
        /// <returns></returns>
        public IUIManager GetUIManager()
        {
            return uiManager;
        }

        /// <summary>
        /// Get game manager
        /// </summary>
        /// <returns></returns>
        public IGameManager GetGameManager()
        {
            return gameManager;
        }

        /// <summary>
        /// Get service manager
        /// </summary>
        /// <returns></returns>
        public IServiceManager GetServiceManager()
        {
            return serviceManager;
        }

        /// <summary>
        /// Get module manager
        /// </summary>
        /// <returns></returns>
        public IModuleManager GetModuleManager()
        {
            return moduleManager;
        }
    }
}