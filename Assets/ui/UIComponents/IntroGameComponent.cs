using DI;
using DI.interfaces;
using DI.UI;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace ui.MainMenu
{
    public class IntroGameComponent : IUIComponent
    {
        private GameObject selfGameObject;
        private IUIPrefabManager uiPrefabManager;

        public IntroGameComponent(IUIPrefabManager uiPrefabManager)
        {
            this.uiPrefabManager = uiPrefabManager;
        }


        public IUIComponent Show()
        {
            if (selfGameObject != null)
            {
                return this;
            }

            selfGameObject = uiPrefabManager.GetPrefab(Prefabs.IntroGameLevel);
            selfGameObject.name = "IntroGame";
            return this;
        }

        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
    }
}