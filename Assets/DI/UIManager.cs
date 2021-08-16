using DI.UI;
using UI.Navigator;
using UI.PrefabManager;
using UnityEngine;

namespace DI
{
    public class UIManager : IUIManager
    {
        private Navigator navigator;
        private IUIPrefabManager uiPrefabManager;
        
        public UIManager ()
        {
            uiPrefabManager = new UIPrefabManager();
            navigator = new Navigator(uiPrefabManager);
        }

        public Navigator GetNavigator()
        {
            return navigator;
        }
    }
}