using System;
using DI.Models;
using UI.Camera;
using UI.DataSaver;
using UI.Games.FinalGame;
using UI.Games.IntroGame;
using UI.Games.MarioGame;
using UI.Games.Menus;
using UI.Games.progressScreen;
using UI.Navigation;
using UI.Player;
using UI.Timer;

namespace UI.Games.GameManager.Interfaces
{
    public interface IGameManager
    { 
        void GetCameraSystem(Action<CameraSystem> success, Action<BaseError> failure );
        void GetMainMenu(Action<MainMenu> success, Action<BaseError> failure);
        void GetIntroLevel(Action<IntroLevel> success, Action<BaseError> failure);
        void GetMarioLevel(Action<MarioLevel> success, Action<BaseError> failure);
        void GetFinalLevel(Action<FinalLevel> success, Action<BaseError> failure);
        void GetPlayer(Action<PlayerBehaviour> success, Action<BaseError> failure);
        void GetLoadingScreen(Action<LoadingScreen> success, Action<BaseError> failure);
        
        void GetNavigationMenu(Action<NavigationMenu> success, Action<BaseError> failure);
        void GetPauseMenu(Action<PauseMenu> success, Action<BaseError> failure);
        void GetTimerManager(Action<TimerManager> success, Action<BaseError> failure);
        void GetGameOverMenu(Action<GameOverMenu> success, Action<BaseError> failure);
        void GetStatisticsData(Action<StatisticsDataCollector> success, Action<BaseError> failure); 
        
        void SetCameraSystem( );
        void SetMainMenu( );
        void SetIntroLevel( );
        void SetMainLevel(  );
        void SetFinalLevel(  );
        void SetPlayer(  );
        void SetLoadingScreen( );
        void SetNavigationMenu();
      
        void SetPauseMenu( );
        void SetTimerManager( );
        void SetGameOverMenu( );
        void SetStatisticsData( );
    }
}