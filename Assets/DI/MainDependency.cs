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
        private IReferenсeManager referenсeManager;
        private InteractorManager interactorManager;

        public void Start()
        {
            instance = this;

            referenсeManager = gameObject.AddComponent<ReferenceManager>();
            moduleManager = new ModuleManager();
            uiManager = new UIManager();
            serviceManager = new ServiceManager(moduleManager);
            interactorManager = new InteractorManager(uiManager, referenсeManager);
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
        /// Get reference manager
        /// </summary>
        /// <returns></returns>
        public IReferenсeManager GetReferenceManager()
        {
            return referenсeManager;
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