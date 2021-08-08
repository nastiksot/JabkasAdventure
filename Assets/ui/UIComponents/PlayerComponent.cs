using DI.UI;
using UnityEngine;

namespace ui.MainMenu
{
    public class PlayerComponent : IUIComponent
    {
        private GameObject selfGameObject;
        private IUIPrefabManager uiPrefabManager;

        public PlayerComponent(IUIPrefabManager uiPrefabManager)
        {
            this.uiPrefabManager = uiPrefabManager;
        }


        public IUIComponent Show()
        {
            if (selfGameObject != null)
            {
                return this;
            }

            selfGameObject = uiPrefabManager.GetPrefab(Prefabs.Player);
            selfGameObject.name = "Player";
            return this;
        }

        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
    }
}