
    using System;

    namespace Services.Navigator.interfaces
    {
        public interface IMainNavigatorServices
        {
            IMenuNavigatorService GetMenuNavigatorService();
            void CloseAll();
            void AddActionForClose(Action action);
        }
    }
