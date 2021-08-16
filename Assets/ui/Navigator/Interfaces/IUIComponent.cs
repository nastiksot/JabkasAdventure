using System;
using DI.UI;

namespace UI.Navigator.Interfaces
{
    public interface IUIComponent
    {
        IUIComponent Show();

        public event Action<Prefabs> OnGameComponentInstantiated;
        void Remove();
    }
}