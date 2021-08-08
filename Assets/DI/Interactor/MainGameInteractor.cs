using DI.interfaces;
using DI.UI; 

namespace DI.Interactor
{ 
    public class MainGameInteractor : IMainGameInteractor
    {
        public MainGameInteractor(INavigator navigator)
        { 
            navigator.CloseAll();
            navigator.StartMainMenu();
        }
    }
}