using System;
using DI.UI;
using UI.Games.IntroGame;
using UI.Navigator.Interfaces;
using UnityEngine;

namespace UI.UIComponents
{
    public class IntroLevelComponent : IUIComponent
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

        public IntroLevelComponent(IUIPrefabManager uiPrefabManager)
        {
            this.uiPrefabManager = uiPrefabManager;
        }


        public IUIComponent Show()
        {
            if (selfGameObject != null)
            {
                return this;
            }

            prefabPath = Prefabs.IntroGameLevel;
            selfGameObject = uiPrefabManager.GetPrefab(prefabPath);
            selfGameObject.name = "IntroGame";
            onGameComponentInstantiated?.Invoke(prefabPath);

            return this;
        }

        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
    }
}