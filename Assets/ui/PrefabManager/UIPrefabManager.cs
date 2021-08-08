using System.Collections.Generic;
using DI.UI;
using UnityEngine;

namespace ui.PrefabManager
{
    public class UIPrefabManager : IUIPrefabManager
    {
        private Dictionary<Prefabs, string> paths = new Dictionary<Prefabs, string>();

        public UIPrefabManager()
        {
            paths[Prefabs.Player] = "Prefab/Player";
            paths[Prefabs.IntroGameLevel] = "Prefab/IntroLevel";
            paths[Prefabs.MainGameLevel] = "Prefab/MarioGame";
            paths[Prefabs.LoadingScreen] = "Prefab/ProgressBar";
            paths[Prefabs.MainMenu] = "Prefab/MainMenuCanvas";
            paths[Prefabs.NavigationMenu] = "Prefab/ControllPlayer";
        }

        public GameObject GetPrefab(Prefabs prefab)
        {
            return GameObject.Instantiate(Resources.Load<GameObject>(paths[prefab]));
        }
    }
}