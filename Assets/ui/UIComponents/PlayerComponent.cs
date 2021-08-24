using System;
using DI.UI;
using UI.Navigator.Interfaces;
using UI.Player;
using UnityEngine;

namespace UI.UIComponents
{
    public class PlayerComponent : IUIComponent
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

            prefabPath = Prefabs.Player;
            selfGameObject = uiPrefabManager.GetPrefab(prefabPath);

            onGameComponentInstantiated?.Invoke(prefabPath);

            return this;
        }

        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
    }
}