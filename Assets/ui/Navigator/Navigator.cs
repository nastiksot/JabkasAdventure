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
        private IReferenсeManager referenсeManager;
        private Dictionary<ComponentsIDs, IUIComponent> components = new Dictionary<ComponentsIDs, IUIComponent>();

        public Navigator(IUIPrefabManager uiPrefabManager)
        {
            referenсeManager = MainDependency.GetInstance().GetReferenceManager();
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
                    referenсeManager.SetPlayer( );
                    break;
                case Prefabs.IntroGameLevel:
                    referenсeManager.SetIntroLevel( );
                    break;
                case Prefabs.MainGameLevel:
                    referenсeManager.SetMainLevel();
                    referenсeManager.SetLevelManager();
                    break;
                case Prefabs.FinalGameLevel:
                    referenсeManager.SetFinalLevel();
                    break;
                case Prefabs.LoadingScreen:
                    referenсeManager.SetLoadingScreen();
                    break;
                case Prefabs.MainMenu:
                    referenсeManager.SetMainMenu();
                    break;
                case Prefabs.NavigationMenu:
                    referenсeManager.SetNavigationMenu();
                    break;
                case Prefabs.PauseMenu:
                    referenсeManager.SetPauseMenu();
                    break;
                case Prefabs.GameOverMenu:
                    referenсeManager.SetGameOverMenu();
                    break;
                case Prefabs.StatisticsData:
                    referenсeManager.SetStatisticsData();
                    referenсeManager.SetTimerManager();
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

        public void InitMarioLevel()
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