using DI.UI;
using UnityEngine;

namespace ui.MainMenu
{
    public class LoadingScreenComponent : IUIComponent
    {

        private GameObject selfGameObject;
        private IUIPrefabManager uiPrefabManager;

        public LoadingScreenComponent(IUIPrefabManager uiPrefabManager)
        {
            this.uiPrefabManager = uiPrefabManager;
        }


        public IUIComponent Show()
        {
            if (selfGameObject != null)
            {
                return this;
            }

            selfGameObject = uiPrefabManager.GetPrefab(Prefabs.LoadingScreen);
            selfGameObject.name = "Loading Screen";
            return this;
        }

        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
    }
}