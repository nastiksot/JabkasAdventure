using DI.interfaces;
using DI.UI;
using UI.Base;

namespace DI
{
    public class MainDependency : BaseMono, IMainDependencys
    {
        private static IMainDependencys instance;
        private IServiceManager serviceManager;
        private IModuleManager moduleManager;
        private IUIManager uiManager;
        private InteractorManager interactorManager;

        public void Start()
        {
            instance = this;

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