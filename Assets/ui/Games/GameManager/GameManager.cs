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
        [SerializeField] private TimeUIManager timeUIManager;

        /// <summary>
        /// Get camera system 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
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

        /// <summary>
        /// Get main menu 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
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

        /// <summary>
        /// Get intro level  
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
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

        /// <summary>
        /// Get mario level
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
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

        /// <summary>
        /// Get final level
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
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

        /// <summary>
        /// Get player script
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
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

        /// <summary>
        /// Get loading screen 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
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

        /// <summary>
        /// Get navigation menu
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
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

        /// <summary>
        /// Get pause menu
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
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

        /// <summary>
        /// Get timer manager
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void GetTimerManager(Action<TimeUIManager> success, Action<BaseError> failure)
        {
            if (timeUIManager != null)
            {
                success?.Invoke(timeUIManager);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_TIMER_MANAGER, "Fail to load timer manager"));
            }
        }

        /// <summary>
        /// Get game over menu
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void GetGameOverMenu(Action<GameOverMenu> success, Action<BaseError> failure)
        {
            if (gameOverMenu != null)
            {
                success?.Invoke(gameOverMenu);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail to load game over menu"));
            }
        }

        /// <summary>
        /// Get statistics data
        /// </summary>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void GetStatisticsData(Action<StatisticsDataCollector> success, Action<BaseError> failure)
        {
            if (statisticsDataCollector != null)
            {
                success?.Invoke(statisticsDataCollector);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail to load statistics data"));
            }
        }

        /// <summary>
        /// Find camera system
        /// </summary>
        public void SetCameraSystem()
        {
            ExtensionUtility.TryToFindObjectOfType(out cameraSystem);
        }

        /// <summary>
        /// Find main menu
        /// </summary>
        public void SetMainMenu()
        {
            ExtensionUtility.TryToFindObjectOfType(out mainMenu);
        }

        /// <summary>
        /// Find intro level
        /// </summary>
        public void SetIntroLevel()
        {
            ExtensionUtility.TryToFindObjectOfType(out introLevel);
        }

        /// <summary>
        /// Find Main level
        /// </summary>
        public void SetMainLevel()
        {
            ExtensionUtility.TryToFindObjectOfType(out marioLevel);
        }

        /// <summary>
        /// Find Final level
        /// </summary>
        public void SetFinalLevel()
        {
            ExtensionUtility.TryToFindObjectOfType(out finalLevel);
        }

        /// <summary>
        /// Find player script
        /// </summary>
        public void SetPlayer()
        {
            ExtensionUtility.TryToFindObjectOfType(out playerBehaviour);
        }

        /// <summary>
        /// Find loading screen
        /// </summary>
        public void SetLoadingScreen()
        {
            ExtensionUtility.TryToFindObjectOfType(out loadingScreen);
        }

        /// <summary>
        /// Find Navigation menu
        /// </summary>
        public void SetNavigationMenu()
        {
            ExtensionUtility.TryToFindObjectOfType(out navigationMenu);
        }

        /// <summary>
        /// Find pause menu
        /// </summary>
        public void SetPauseMenu()
        {
            ExtensionUtility.TryToFindObjectOfType(out pauseMenu);
        }

        /// <summary>
        /// Find timer manager
        /// </summary>
        public void SetTimerManager()
        {
            ExtensionUtility.TryToFindObjectOfType(out timeUIManager);
        }

        /// <summary>
        /// Find Game over menu
        /// </summary>
        public void SetGameOverMenu()
        {
            ExtensionUtility.TryToFindObjectOfType(out gameOverMenu);
        }

        /// <summary>
        /// Find statistics data collector
        /// </summary>
        public void SetStatisticsData()
        {
            ExtensionUtility.TryToFindObjectOfType(out statisticsDataCollector);
        }
    }
}