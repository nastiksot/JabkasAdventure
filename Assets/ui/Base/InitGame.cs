namespace UI.Base
{
  public class InitGame : BaseMono
  {
    private void Start()
    {
      MainDependency.GetInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenMainMenu();
    }
  }
}
