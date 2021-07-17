namespace DI.interfaces
{
    public interface IMainDependencys
    {
        IServiceManager GetServiceManager();
        IModuleManager GetModuleManager();
    }
}
