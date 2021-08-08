namespace DI.UI
{
    public interface INavigator
    {
        void CloseAll();

        void StartMainMenu();
        void StartIntroLevel();
        void StartMainLevel();
        void StartFinalLevel();
        void InitPlayer();
        void StartLoadingScreen();
        void InitNavigationMenu();
        void InitPauseMenu();
        void InitGameOverMenu();
        void InitStatisticsData();
    }
}