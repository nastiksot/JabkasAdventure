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
            interactorManager = new InteractorManager(serviceManager, uiManager);
        }

        public static IMainDependencys GetInstance()
        {
            if (instance == null)
            {
                instance = new MainDependency();
            }

            return instance;
        }

        public IUIManager GetUIManager()
        {
            return uiManager;
        }
       public IGameManager GetGameManager()
        {
            return gameManager;
        }

        public IServiceManager GetServiceManager()
        {
            return serviceManager;
        }

        public IModuleManager GetModuleManager()
        {
            return moduleManager;
        }
    }
}