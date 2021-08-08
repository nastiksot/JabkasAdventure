using DI;
using DI.interfaces;
using DI.UI;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace ui.MainMenu
{
    public class MainMenuComponent : IUIComponent
    {
        private GameObject selfGameObject;
        private IUIPrefabManager uiPrefabManager;

        public MainMenuComponent(IUIPrefabManager uiPrefabManager)
        {
            this.uiPrefabManager = uiPrefabManager;
        }


        public IUIComponent Show()
        {
            if (selfGameObject != null)
            {
                return this;
            }

            selfGameObject = uiPrefabManager.GetPrefab(Prefabs.MainMenu);
            selfGameObject.name = "MainMenu";
            return this;
        }

        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
    }
}