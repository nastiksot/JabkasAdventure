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

    public void openMainMenu()
    {
        getMainNavigation().closeAll();
           
            var mainMenu = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.MAIN_MENU));
            getMainNavigation().addActionForClose(() => BaseMono.Destroy(mainMenu));
 }

    public void openIntroGame()
    {
        getMainNavigation().closeAll();
        var introGame = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.INTRO_GAME_LEVEL));
        var controllers = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.CONTROLS));
        getMainNavigation().addActionForClose(() =>
        {
            BaseMono.Destroy(introGame);
            BaseMono.Destroy(controllers);
        });
    }

    public void openMarioGame()
    {
        getMainNavigation().closeAll();
        var marioGame = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.MARIO_GAME_LEVEL));
        var controllers = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.CONTROLS));
        getMainNavigation().addActionForClose(() =>
        {
            BaseMono.Destroy(marioGame);
            BaseMono.Destroy(controllers);
        });
    }
}