using System.Collections.Generic;
using DI.UI;
using ui.MainMenu;

namespace ui.Navigator
{
    public class Navigator : INavigator
    {
        private Dictionary<ComponentsIDs, IUIComponent> components = new Dictionary<ComponentsIDs, IUIComponent>();

        public Navigator(IUIPrefabManager uiPrefabManager)
        {
            components[ComponentsIDs.MainMenu] = new MainMenuComponent(uiPrefabManager);
            components[ComponentsIDs.Player] = new PlayerComponent(uiPrefabManager);
            components[ComponentsIDs.IntroLevel] = new IntroGameComponent(uiPrefabManager);
            components[ComponentsIDs.NavigationMenu] = new NavigationMenuComponent(uiPrefabManager);
            components[ComponentsIDs.LoadingScreen] = new LoadingScreenComponent(uiPrefabManager);
            components[ComponentsIDs.MainLevel] = new MainLevelComponent(uiPrefabManager);
            components[ComponentsIDs.PauseMenu] = new PauseMenuComponent(uiPrefabManager);
            components[ComponentsIDs.GameOverMenu] = new GameOverMenuComponent(uiPrefabManager);
            components[ComponentsIDs.StatisticsData] = new StatisticsDataComponent(uiPrefabManager);
            //components[ComponentsIDs.ProgressBar] = new MainMenuComponent(uiPrefabManager);
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

        public void StartMainMenu()
        {
            CloseAll();
            components[ComponentsIDs.MainMenu].Show();
        }

        public void StartIntroLevel()
        {
            CloseAll();
            InitPlayer();
            components[ComponentsIDs.IntroLevel].Show();
            InitNavigationMenu();
        }

        public void StartMainLevel()
        {
            CloseAll();
            InitPlayer();
            components[ComponentsIDs.MainLevel].Show();
            InitNavigationMenu();
            InitPauseMenu();
            InitStatisticsData();
            InitGameOverMenu();
        }

        public void StartFinalLevel()
        {
            CloseAll();
            components[ComponentsIDs.FinalLevel].Show();
        }
    }
}