public class ServiceManagerImpl : ServiceManager
{
    private MainNavigatorServices mainNavigatorServices;


    public ServiceManagerImpl()
    {
        var menuNavigatorService = new MenuNavigatorServiceImpl();
        mainNavigatorServices = new MainNavigatorServicesImpl(menuNavigatorService);
    }

    public MainNavigatorServices GetMainNavigatorService()
    {
        return mainNavigatorServices;
    }
}