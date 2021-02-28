
    using System;

    public interface MainNavigatorServices
    {
        MenuNavigatorService GetMenuNavigatorService();
        void closeAll();
    
        void addActionForClose(Action action);
    }
