namespace UI.Base
{
  public class InitGame : BaseMono
  {
    private void Start()
    {
      MainDependency.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenMainMenu();
    }
  }
}
