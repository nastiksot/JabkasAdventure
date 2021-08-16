using DI.Interfaces;
using DI.UI; 

namespace DI.Interactor
{ 
    public class MainGameInteractor : IMainGameInteractor
    {
        public MainGameInteractor(INavigator navigator)
        { 
            navigator.CloseAll();
            navigator.InitMainMenu();
        }
    }
}