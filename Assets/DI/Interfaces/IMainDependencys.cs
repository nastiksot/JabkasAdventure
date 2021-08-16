using DI.UI;
using UI.Games.GameManager.Interfaces;

namespace DI.Interfaces
{
    public interface IMainDependencys
    {
        IUIManager GetUIManager();
        IGameManager GetGameManager();
        IServiceManager GetServiceManager();
        IModuleManager GetModuleManager();
    }
}
