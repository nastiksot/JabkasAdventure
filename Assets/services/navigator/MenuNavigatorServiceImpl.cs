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
        // MainDependencyImpl.getInstance().GetServiceManager().GetDataService().GetUser(profile =>
        // {
        //     Debug.Log("Now user is " + profile.nickname);
        // }, error =>
        // {
        //     Debug.LogError(error.errorMessage);
        // });
        //
        // MainDependencyImpl.getInstance().GetServiceManager().GetDataService().GetUserProgress(profile =>
        // {
        //     Debug.Log("UserProgress");
        // }, error =>
        // {
        //     Debug.LogError(error.errorMessage);
        // });

    }

    public void openIntroGame()
    {
        getMainNavigation().closeAll();
        var introGame = BaseMono.Instantiate(Resources.Load<GameObject>(PrefabsPaths.INTRO_GAME_LEVEL));
        getMainNavigation().addActionForClose(() => BaseMono.Destroy(introGame));
    }
}