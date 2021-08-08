using DI.UI;
using UnityEngine;

namespace ui.MainMenu
{
    public class NavigationMenuComponent : IUIComponent
    {
        private GameObject selfGameObject;
        private IUIPrefabManager uiPrefabManager;

        public NavigationMenuComponent(IUIPrefabManager uiPrefabManager)
        {
            this.uiPrefabManager = uiPrefabManager;
        }


        public IUIComponent Show()
        {
            if (selfGameObject != null)
            {
                return this;
            }

            selfGameObject = uiPrefabManager.GetPrefab(Prefabs.NavigationMenu);
            selfGameObject.name = "Navigation Menu";
            return this;
        }

        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
    }
}