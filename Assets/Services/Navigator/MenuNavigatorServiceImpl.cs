using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigatorServiceImpl : MenuNavigatorService
{
    private GameObject mainMenu;

    private MainNavigatorServices getMainNavigation()
    {
        return MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService();
    }

    public void OpenMainMenu()
    {
        getMainNavigation().CloseAll();
        var mainMenu = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.MAIN_MENU));
            getMainNavigation().AddActionForClose(() => BaseMono.Destroy(mainMenu));
 }

    public void OpenIntroLevel()
    {
        getMainNavigation().CloseAll();
        var introGame = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.INTRO_GAME_LEVEL));
        var controllers = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.CONTROLS));
        var player = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.PLAYER));
        getMainNavigation().AddActionForClose(() =>
        {
            BaseMono.Destroy(introGame);
            BaseMono.Destroy(controllers);
            BaseMono.Destroy(player);
        });
    }

    public void OpenMarioLevel()
    {
        getMainNavigation().CloseAll();
        var marioGame = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.MARIO_GAME_LEVEL));
        var controllers = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.CONTROLS));
        var player = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.PLAYER));
        getMainNavigation().AddActionForClose(() =>
        {
            BaseMono.Destroy(marioGame);
            BaseMono.Destroy(player);
            BaseMono.Destroy(controllers);
        }); 
    }
    public void OpenProgressBar()
    {
        getMainNavigation().CloseAll();
        var progressBar = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.PROGRESS_BAR));
       
        getMainNavigation().AddActionForClose(() =>
        {
            BaseMono.Destroy(progressBar); 
        });
    }
}