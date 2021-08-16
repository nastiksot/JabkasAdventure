using System;
using DI.UI;
using UI.Games.MarioGame;
using UI.Navigator.Interfaces;
using UnityEngine;

namespace UI.UIComponents
{
    public class MainLevelComponent : IUIComponent
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

        public MainLevelComponent(IUIPrefabManager uiPrefabManager)
        {
            this.uiPrefabManager = uiPrefabManager;
        }


        public IUIComponent Show()
        {
            prefabPath = Prefabs.MainGameLevel;
            if (selfGameObject != null)
            {
                return this;
            }

            selfGameObject = uiPrefabManager.GetPrefab(prefabPath);
            selfGameObject.name = "Main Game";
            onGameComponentInstantiated?.Invoke(prefabPath);
            return this;
        }

        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
    }
}