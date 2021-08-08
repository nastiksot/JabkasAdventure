using System;
using System.Collections.Generic;
using Services.Navigator.interfaces;

namespace Services.Navigator
{
    public class MainNavigatorServices : IMainNavigatorServices
    {
        private List<Action> needToClose = new List<Action>();
        private IMenuNavigatorService menuNavigatorService;

        public MainNavigatorServices(IMenuNavigatorService menuNavigatorService)
        {
            this.menuNavigatorService = menuNavigatorService;
        }

        public IMenuNavigatorService GetMenuNavigatorService()
        {
            return menuNavigatorService;
        }

        public void CloseAll()
        {
            if (needToClose == null) return;

            foreach (var action in needToClose)
            {
                action.Invoke();
            }

            needToClose.Clear();
        }

        public void AddActionForClose(Action action)
        {
            needToClose.Add(action);
        }
    }
}