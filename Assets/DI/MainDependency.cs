using DI.interfaces;

namespace DI
{
    public class MainDependency : IMainDependencys
    {
        private static IMainDependencys instance = new MainDependency();
        private IServiceManager serviceManager;
        private IModuleManager moduleManager;

        public MainDependency()
        {
            moduleManager = new ModuleManager();
            serviceManager = new ServiceManager(moduleManager);
        }

        public static IMainDependencys GetInstance()
        {
            return instance;
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