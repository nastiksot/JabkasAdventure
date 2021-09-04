﻿using System;
using DI.UI;
using UI.Navigator.Interfaces;
using UnityEngine;

namespace UI.UIComponents
{
    public class MainMenuComponent : IUIComponent
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

            prefabPath = Prefabs.MainMenu;
            selfGameObject = uiPrefabManager.GetPrefab(prefabPath);

            onGameComponentInstantiated?.Invoke(prefabPath);
            selfGameObject.name = "MainMenu";
            return this;
        }

        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
    }
}