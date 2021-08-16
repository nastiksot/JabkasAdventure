using System;
using DI.UI;
using UI.Games.Menus;
using UI.Navigator.Interfaces;
using UnityEngine;

namespace UI.UIComponents
{
    public class PauseMenuComponent : IUIComponent
    {
        private GameObject selfGameObject;
        private IUIPrefabManager uiPrefabManager;
        private Prefabs prefabPath;
        private Action<Prefabs> onGameComponentInstantiated;
        public event Action<Prefabs> OnGameComponentInstantiated
        {
            add => onGameComponentInstantiated += value;
            remove => onGameComponentInstantiated -= value;
        }
        public PauseMenuComponent(IUIPrefabManager uiPrefabManager)
        {
            this.uiPrefabManager = uiPrefabManager;
        }


        public IUIComponent Show()
        {
            if (selfGameObject != null)
            {
                return this;
            }
            prefabPath = Prefabs.PauseMenu;
            selfGameObject = uiPrefabManager.GetPrefab(prefabPath);
            onGameComponentInstantiated?.Invoke(prefabPath );
            selfGameObject.name = "Pause Menu";
            return this;
        }

        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
    }
}