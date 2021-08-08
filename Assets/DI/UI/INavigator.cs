namespace DI.UI
{
    public interface INavigator
    {
        void CloseAll();
        void NavigationMenu();
        void InitPlayer();
        void StartLoadingScreen();
        void StartMainMenu();
        void StartIntroLevel();
        void StartMainLevel();
        void StartFinalLevel();
    }
}