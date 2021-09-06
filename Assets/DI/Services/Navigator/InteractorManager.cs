using DI.Interactor;
using DI.Interfaces;
using DI.UI;
using UI.Games.GameManager.Interfaces;

namespace DI.Services.Navigator
{
    public class InteractorManager
    {
        private IMainGameInteractor mainGameInteractor;

        public InteractorManager( IUIManager manager, IReferenсeManager referenсeManager)
        {
            mainGameInteractor = new MainGameInteractor(manager.GetNavigator(), referenсeManager);
        }
    }
}