using DI.interfaces;
using Services.Navigator;
using Services.Navigator.interfaces;

namespace DI
{
    public class ServiceManager : IServiceManager
    {
        private IMainNavigatorServices mainNavigatorServices;


        public ServiceManager()
        {
            var menuNavigatorService = new MenuNavigatorService();
            mainNavigatorServices = new MainNavigatorServices(menuNavigatorService);
        }

        public IMainNavigatorServices GetMainNavigatorService()
        {
            return mainNavigatorServices;
        }
    }
}