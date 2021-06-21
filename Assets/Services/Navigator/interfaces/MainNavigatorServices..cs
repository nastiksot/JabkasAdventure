
    using System;

    public interface MainNavigatorServices
    {
        MenuNavigatorService GetMenuNavigatorService();
        void CloseAll();
        void AddActionForClose(Action action);
    }
