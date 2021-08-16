using DI.Interactor;
using DI.Interfaces;
using DI.UI;

namespace DI.Services.Navigator
{
    public class InteractorManager
    {
        private IMainGameInteractor mainGameInteractor;

        public InteractorManager(IServiceManager serviceManager, IUIManager manager)
        {
            mainGameInteractor = new MainGameInteractor(manager.GetNavigator());
        }
    }
}