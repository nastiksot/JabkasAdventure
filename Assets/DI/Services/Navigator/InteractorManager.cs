using DI.Interactor;
using DI.interfaces;
using DI.UI; 

public class InteractorManager
{
    private IMainGameInteractor mainGameInteractor;

    public InteractorManager(IServiceManager serviceManager, IUIManager manager)
    {
        mainGameInteractor = new MainGameInteractor(manager.GetNavigator());
    }
}