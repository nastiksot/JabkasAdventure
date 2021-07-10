namespace UI.Base
{
  public class InitGame : BaseMono
  {
    private void Start()
    {
      MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenMainMenu();
    }
  }
}
