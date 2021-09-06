namespace DI.UI
{
    public interface INavigator
    {
        void CloseAll();

        void InitMainMenu();
        void InitIntroLevel();
        void InitMarioLevel();
        void InitFinalLevel();
        void InitPlayer();
        void StartLoadingScreen();
        void InitNavigationMenu();
        void InitPauseMenu();
        void InitGameOverMenu();
        void InitStatisticsData();
    }
}