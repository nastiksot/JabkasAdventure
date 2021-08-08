using DI.UI;

namespace DI.interfaces
{
    public interface IMainDependencys
    {
        IUIManager GetUIManager();
        IServiceManager GetServiceManager();
        IModuleManager GetModuleManager();
    }
}
