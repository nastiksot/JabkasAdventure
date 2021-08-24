using DI.Interfaces;
using DI.UI;
using UI.Games.GameManager.Interfaces;

namespace DI.Interactor
{
    public class MainGameInteractor : IMainGameInteractor
    {
        public MainGameInteractor(INavigator navigator, IGameManager gameManager)
        {
            navigator.CloseAll();
            navigator.InitMainMenu();
            gameManager.SetCameraSystem();
        }
    }
}