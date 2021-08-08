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
            components[ComponentsIDs.IntroLevel] = new IntroGameComponent(uiPrefabManager);
            components[ComponentsIDs.Player] = new PlayerComponent(uiPrefabManager);
            components[ComponentsIDs.NavigationMenu] = new NavigationMenuComponent(uiPrefabManager);
            // components[ComponentsIDs.FinalLevel] = new MainMenuComponent(uiPrefabManager);
            // components[ComponentsIDs.ProgressBar] = new MainMenuComponent(uiPrefabManager);
        }

        public void CloseAll()
        {
            foreach (var keyValuePair in components)
            {
                keyValuePair.Value.Remove();
            }
        }

        public void NavigationMenu()
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
            components[ComponentsIDs.ProgressBar].Show();
        }

        public void StartMainMenu()
        {
            CloseAll();
            components[ComponentsIDs.MainMenu].Show();
        }

        public void StartIntroLevel()
        {
            CloseAll();
            components[ComponentsIDs.IntroLevel].Show();
            InitPlayer();
            NavigationMenu();
        }

        public void StartMainLevel()
        {
            CloseAll();
            components[ComponentsIDs.MainLevel].Show();
        }

        public void StartFinalLevel()
        {
            CloseAll();
            components[ComponentsIDs.FinalLevel].Show();
        }
    }
}