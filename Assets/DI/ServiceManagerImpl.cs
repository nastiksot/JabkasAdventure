using Services.Navigator;
using Services.Navigator.interfaces;

public class ServiceManagerImpl : ServiceManager
{
    private IMainNavigatorServices mainNavigatorServices;


    public ServiceManagerImpl()
    {
        var menuNavigatorService = new MenuNavigatorService();
        mainNavigatorServices = new MainNavigatorServices(menuNavigatorService);
    }

    public IMainNavigatorServices GetMainNavigatorService()
    {
        return mainNavigatorServices;
    }
}