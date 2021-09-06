using DI.Interfaces;
using DI.UI;
using UI.Games.GameManager.Interfaces;

namespace DI.Interactor
{
    public class MainGameInteractor : IMainGameInteractor
    {
        public MainGameInteractor(INavigator navigator, IReferenсeManager referenсeManager)
        {
            navigator.CloseAll();
            navigator.InitMainMenu();
            referenсeManager.SetCameraSystem();
        }
    }
}