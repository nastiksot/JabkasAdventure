using UnityEngine;

namespace DI.UI
{
    public enum Prefabs
    {
        Player,
        IntroGameLevel,
        MainGameLevel,
        FinalGameLevel,
        LoadingScreen,
        MainMenu,
        NavigationMenu
    }

    public interface IUIPrefabManager
    {
        GameObject GetPrefab(Prefabs prefab);
    }
}