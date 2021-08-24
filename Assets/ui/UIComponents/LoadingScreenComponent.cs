using System;
using DI.UI;
using UI.Games.progressScreen;
using UI.Navigator.Interfaces;
using UnityEngine;

namespace UI.UIComponents
{
    public class LoadingScreenComponent : IUIComponent
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

            prefabPath = Prefabs.LoadingScreen;
            selfGameObject = uiPrefabManager.GetPrefab(prefabPath);
            selfGameObject.name = "Loading Screen";
            onGameComponentInstantiated?.Invoke(prefabPath);

            return this;
        }

        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
    }
}