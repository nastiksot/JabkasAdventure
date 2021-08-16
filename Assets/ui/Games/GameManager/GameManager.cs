using System;
using System.Collections.Generic;
using DI.Models;
using DI.UI;
using UI.Base;
using UI.DataSaver;
using UI.Games.FinalGame;
using UI.Games.GameManager.Interfaces;
using UI.Games.IntroGame;
using UI.Games.Menus;
using UI.Games.MarioGame;
using UI.Games.progressScreen;
using UI.Navigation;
using UI.Player;
using UnityEngine;

namespace UI.Games.GameManager
{
    public class GameManager : BaseMono, IGameManager
    {
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

        public void CloseAll()
        {
            throw new NotImplementedException();
        }

        public void GetMainMenu(Action<MainMenu> success, Action<BaseError> failure)
        {
            if (mainMenu != null)
            {
                success?.Invoke(mainMenu);
            }
            else
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail load main menu"));
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
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_INTRO_LEVEL, "Fail load intro level"));
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
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MARIO_LEVEL, "Fail load mario level"));
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
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_FINAL_LEVEL, "Fail load final level"));
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
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_PLAYER, "Fail load player"));
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
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail load main menu"));
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
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail load main menu"));
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
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail load main menu"));
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
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_MAIN_MENU, "Fail load main menu"));
            }
        }

        public void SetMainMenu()
        {
            mainMenu = FindObjectOfType<MainMenu>();
        }

        public void SetIntroLevel()
        {
            introLevel = FindObjectOfType<IntroLevel>();
        }

        public void SetMainLevel()
        {
            marioLevel = FindObjectOfType<MarioLevel>();
        }

        public void SetFinalLevel()
        {
            finalLevel = FindObjectOfType<FinalLevel>();
        }

        public void SetPlayer()
        {
            playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        }

        public void SetLoadingScreen()
        {
            loadingScreen = FindObjectOfType<LoadingScreen>();
        }

        public void SetNavigationMenu()
        {
            navigationMenu = FindObjectOfType<NavigationMenu>();
        }

        public void SetPauseMenu()
        {
            pauseMenu = FindObjectOfType<PauseMenu>();
        }

        public void SetGameOverMenu()
        {
            gameOverMenu = FindObjectOfType<GameOverMenu>();
        }

        public void SetStatisticsData()
        {
            statisticsDataCollector = FindObjectOfType<StatisticsDataCollector>();
        }
    }
}