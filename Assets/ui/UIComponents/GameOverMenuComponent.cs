using System;
using DI.UI;
using UI.Games.Menus;
using UI.Navigator.Interfaces;
using UnityEngine;

namespace UI.UIComponents
{
    public class GameOverMenuComponent: IUIComponent
    {
        private GameObject selfGameObject;
        private IUIPrefabManager uiPrefabManager;
        private Action<Prefabs> onGameComponentInstantiated;
        private Prefabs prefabPath;
        public event Action<Prefabs> OnGameComponentInstantiated
        {
            add => onGameComponentInstantiated += value;
            remove => onGameComponentInstantiated -= value;
        }
        
        public GameOverMenuComponent(IUIPrefabManager uiPrefabManager)
        {
            this.uiPrefabManager = uiPrefabManager;
        } 

        public IUIComponent Show()
        {
            if (selfGameObject != null)
            {
                return this;
            }

            prefabPath = Prefabs.GameOverMenu;
            selfGameObject = uiPrefabManager.GetPrefab(Prefabs.GameOverMenu);
            selfGameObject.name = "Game Over Menu"; 
            onGameComponentInstantiated?.Invoke(prefabPath);

            return this;
        }
 
        public void Remove()
        {
            MonoBehaviour.Destroy(selfGameObject);
        }
         
    }
}