using System;
using System.Collections.Generic;
using DI;
using DI.UI;
using UI.Games.GameManager.Interfaces;
using UI.Games.IntroGame;
using UI.Navigator.Interfaces;
using UI.Player;
using UI.UIComponents;

namespace UI.Navigator
{
    public class Navigator : INavigator
    {
        private IGameManager gameManager;
        private Dictionary<ComponentsIDs, IUIComponent> components = new Dictionary<ComponentsIDs, IUIComponent>();

        public Navigator(IUIPrefabManager uiPrefabManager)
        {
            gameManager = MainDependency.GetInstance().GetGameManager();
            components[ComponentsIDs.MainMenu] = new MainMenuComponent(uiPrefabManager);
            components[ComponentsIDs.Player] = new PlayerComponent(uiPrefabManager);
            components[ComponentsIDs.IntroLevel] = new IntroLevelComponent(uiPrefabManager);
            components[ComponentsIDs.NavigationMenu] = new NavigationMenuComponent(uiPrefabManager);
            components[ComponentsIDs.LoadingScreen] = new LoadingScreenComponent(uiPrefabManager);
            components[ComponentsIDs.MainLevel] = new MainLevelComponent(uiPrefabManager);
            components[ComponentsIDs.PauseMenu] = new PauseMenuComponent(uiPrefabManager);
            components[ComponentsIDs.GameOverMenu] = new GameOverMenuComponent(uiPrefabManager);
            components[ComponentsIDs.StatisticsData] = new StatisticsDataComponent(uiPrefabManager);
            SubscribeAll(); 
            //components[ComponentsIDs.ProgressBar] = new MainMenuComponent(uiPrefabManager);
        }

        private void SubscribeAll()
        {
            foreach (var component in components)
            {
                component.Value.OnGameComponentInstantiated += OnComponentInstantiated;
            }
        }

        private void OnComponentInstantiated(Prefabs prefabs )
        {
            switch (prefabs)
            {
                case Prefabs.Player:
                    gameManager.SetPlayer( );
                    break;
                case Prefabs.IntroGameLevel:
                    gameManager.SetIntroLevel( );
                    break;
                case Prefabs.MainGameLevel:
                    gameManager.SetMainLevel();
                    gameManager.SetLevelManager();
                    break;
                case Prefabs.FinalGameLevel:
                    gameManager.SetFinalLevel();
                    break;
                case Prefabs.LoadingScreen:
                    gameManager.SetLoadingScreen();
                    break;
                case Prefabs.MainMenu:
                    gameManager.SetMainMenu();
                    break;
                case Prefabs.NavigationMenu:
                    gameManager.SetNavigationMenu();
                    break;
                case Prefabs.PauseMenu:
                    gameManager.SetPauseMenu();
                    break;
                case Prefabs.GameOverMenu:
                    gameManager.SetGameOverMenu();
                    break;
                case Prefabs.StatisticsData:
                    gameManager.SetStatisticsData();
                    gameManager.SetTimerManager();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(prefabs), prefabs, null);
            }
        }

        public void CloseAll()
        {
            foreach (var keyValuePair in components)
            {
                keyValuePair.Value.Remove();
            }
        }

        public void InitNavigationMenu()
        {
            components[ComponentsIDs.NavigationMenu].Show();
        }

        public void InitPlayer()
        {
            components[ComponentsIDs.Player].Show();
        }

        public void StartLoadingScreen()
        {
            CloseAll();
            components[ComponentsIDs.LoadingScreen].Show();
        }
 
        public void InitPauseMenu()
        {
            components[ComponentsIDs.PauseMenu].Show();
        }

        public void InitGameOverMenu()
        {
            components[ComponentsIDs.GameOverMenu].Show();
        }

        public void InitStatisticsData()
        {
            components[ComponentsIDs.StatisticsData].Show();
        }

        public void InitMainMenu()
        {
            CloseAll();
            components[ComponentsIDs.MainMenu].Show();
        }

        public void InitIntroLevel()
        {
            CloseAll();
            InitPlayer();
            components[ComponentsIDs.IntroLevel].Show();
            InitNavigationMenu();
        }

        public void InitMainLevel()
        {
            CloseAll();
            InitPlayer();
            components[ComponentsIDs.MainLevel].Show();
            InitNavigationMenu();
            InitPauseMenu();
            InitStatisticsData();
            InitGameOverMenu();
        }

        public void InitFinalLevel()
        {
            CloseAll();
            components[ComponentsIDs.FinalLevel].Show();
        }
    }
}