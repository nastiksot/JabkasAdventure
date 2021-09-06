using DI.UI;
using UI.Games.GameManager.Interfaces;

namespace DI.Interfaces
{
    public interface IMainDependencys
    {
        IUIManager GetUIManager();
        IReferenсeManager GetReferenceManager();
        IServiceManager GetServiceManager();
        IModuleManager GetModuleManager();
    }
}
