using DI.interfaces;
using Services.Data;
using Services.Data.Interfaces;
using Services.Navigator;
using Services.Navigator.interfaces;

namespace DI
{
    public class ServiceManager : IServiceManager
    {
        private IMainNavigatorServices mainNavigatorServices;
        private IDataService dataService;

        public ServiceManager(IModuleManager moduleManager)
        {
            var menuNavigatorService = new MenuNavigatorService();
            mainNavigatorServices = new MainNavigatorServices(menuNavigatorService);
            
            dataService = new DataService(moduleManager.GetDataModule());
        }

        public IMainNavigatorServices GetMainNavigatorService()
        {
            return mainNavigatorServices;
        }

        public IDataService GetDataService()
        {
            return dataService;
        }
    }
}