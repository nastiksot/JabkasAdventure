using System;
using DI.Models;
using UI.Base;
using UI.Camera;
using UI.DataSaver;
using UI.Games.FinalGame;
using UI.Games.GameManager.Interfaces;
using UI.Games.IntroGame;
using UI.Games.Menus;
using UI.Games.MarioGame;
using UI.Games.progressScreen;
using UI.Navigation;
using UI.Player;
using UI.Timer;
using UnityEngine;

namespace UI.Games.GameManager
{
    public class GameManager : BaseMono, IGameManager
    {
        [SerializeField] private CameraSystem cameraSystem;
        [SerializeField] private PlayerBehaviour playerBehaviour;
        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private MainMenu mainMenu;
        [SerializeField] private GameOverMenu gameOverMenu;
        [SerializeField] private MarioLevel marioLevel;
        [SerializeField] private FinalLevel finalLevel;
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private IntroLevel introLevel;
        [SerializeField] private NavigationMenu navigationMenu;
        [SerializeField] private StatisticsDataCollector statisticsDataCollector;
        [SerializeField] private TimerManager timerManager;

        public void CloseAll()
        {
            throw new NotImplementedException();
        }

        public void GetCameraSystem(Action<CameraSystem> success, Action<BaseError> failure)
        {
            if (cameraSystem != null)
            {
                success?.Invoke(cameraSystem);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail to load main menu"));
            }
        }

        public void GetMainMenu(Action<MainMenu> success, Action<BaseError> failure)
        {
            if (mainMenu != null)
            {
                success?.Invoke(mainMenu);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail to load main menu"));
            }
        }

        public void GetIntroLevel(Action<IntroLevel> success, Action<BaseError> failure)
        {
            if (introLevel != null)
            {
                success?.Invoke(introLevel);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_INTRO_LEVEL, "Fail to load intro level"));
            }
        }

        public void GetMarioLevel(Action<MarioLevel> success, Action<BaseError> failure)
        {
            if (marioLevel != null)
            {
                success?.Invoke(marioLevel);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MARIO_LEVEL, "Fail to load mario level"));
            }
        }

        public void GetFinalLevel(Action<FinalLevel> success, Action<BaseError> failure)
        {
            if (finalLevel != null)
            {
                success?.Invoke(finalLevel);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_FINAL_LEVEL, "Fail to load final level"));
            }
        }

        public void GetPlayer(Action<PlayerBehaviour> success, Action<BaseError> failure)
        {
            if (playerBehaviour != null)
            {
                success?.Invoke(playerBehaviour);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_PLAYER, "Fail to load player"));
            }
        }

        public void GetLoadingScreen(Action<LoadingScreen> success, Action<BaseError> failure)
        {
            if (loadingScreen != null)
            {
                success?.Invoke(loadingScreen);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail to load main menu"));
            }
        }

        public void GetNavigationMenu(Action<NavigationMenu> success, Action<BaseError> failure)
        {
            if (navigationMenu != null)
            {
                success?.Invoke(navigationMenu);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_NAVIGATION_MENU, "Fail to load navigation menu"));
            }
        }
 

        public void GetPauseMenu(Action<PauseMenu> success, Action<BaseError> failure)
        {
            if (pauseMenu != null)
            {
                success?.Invoke(pauseMenu);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail to load main menu"));
            }
        }

        public void GetTimerManager(Action<TimerManager> success, Action<BaseError> failure)
        {
            if (timerManager != null)
            {
                success?.Invoke(timerManager);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_TIMER_MANAGER, "Fail to load timer manager"));
            }
        }

        public void GetGameOverMenu(Action<GameOverMenu> success, Action<BaseError> failure)
        {
            if (gameOverMenu != null)
            {
                success?.Invoke(gameOverMenu);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail to load main menu"));
            }
        }

        public void GetStatisticsData(Action<StatisticsDataCollector> success, Action<BaseError> failure)
        {
            if (statisticsDataCollector != null)
            {
                success?.Invoke(statisticsDataCollector);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail to load main menu"));
            }
        }

        public void SetCameraSystem()
        {
            ExtensionUtility.TryToFindObjectOfType(out cameraSystem);
        }

        public void SetMainMenu()
        {
            ExtensionUtility.TryToFindObjectOfType(out mainMenu);
        }

        public void SetIntroLevel()
        {
            ExtensionUtility.TryToFindObjectOfType(out introLevel);
        }

        public void SetMainLevel()
        {
            ExtensionUtility.TryToFindObjectOfType(out marioLevel);
        }

        public void SetFinalLevel()
        {
            ExtensionUtility.TryToFindObjectOfType(out finalLevel);
        }

        public void SetPlayer()
        {
            ExtensionUtility.TryToFindObjectOfType(out playerBehaviour);
        }

        public void SetLoadingScreen()
        {
            ExtensionUtility.TryToFindObjectOfType(out loadingScreen);
        }

        public void SetNavigationMenu()
        {
            ExtensionUtility.TryToFindObjectOfType(out navigationMenu);
        }

        public void SetPauseMenu()
        {
            ExtensionUtility.TryToFindObjectOfType(out pauseMenu);
        }

        public void SetTimerManager()
        {
            ExtensionUtility.TryToFindObjectOfType(out timerManager);
        }

        public void SetGameOverMenu()
        {
            ExtensionUtility.TryToFindObjectOfType(out gameOverMenu);
        }

        public void SetStatisticsData()
        {
            ExtensionUtility.TryToFindObjectOfType(out statisticsDataCollector);
        }
    }
}