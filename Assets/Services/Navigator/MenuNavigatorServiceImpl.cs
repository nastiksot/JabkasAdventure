using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        getMainNavigation().AddActionForClose(() =>
        {
            BaseMono.Destroy(introGame);
            BaseMono.Destroy(controllers);
        });
    }

    public void OpenMarioLevel()
    {
        getMainNavigation().CloseAll();
        var marioGame = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.MARIO_GAME_LEVEL));
        var controllers = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.CONTROLS));
        getMainNavigation().AddActionForClose(() =>
        {
            BaseMono.Destroy(marioGame);
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