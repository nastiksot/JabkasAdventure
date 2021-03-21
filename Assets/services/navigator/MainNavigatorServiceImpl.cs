
    using System;
    using System.Collections.Generic;

    public class MainNavigatorServicesImpl : MainNavigatorServices
    {
        private List<Action> needToClose = new List<Action>();
        private MenuNavigatorService menuNavigatorService;
        
        public MainNavigatorServicesImpl( MenuNavigatorService menuNavigatorService)
        {   
            this.menuNavigatorService = menuNavigatorService;
        }
        
        public MenuNavigatorService GetMenuNavigatorService()
        {
            return menuNavigatorService;
        }

        public void closeAll()
        {
            foreach (var action in needToClose)
            {
                action.Invoke();
            }
            needToClose.Clear();
        }

        public void addActionForClose(Action action)
        {
            needToClose.Add(action);
        }
    }
