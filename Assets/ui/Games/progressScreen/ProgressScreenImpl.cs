using System.Collections;
using System.Collections.Generic;
using UI.Base;
using UnityEngine;

public class ProgressScreenImpl : BaseMono
{
    void Start()
    {
        OpenMarioGame();
    }

    void OpenMarioGame()
    {
        StartCoroutine( startWithDelay(6,()=>
        {
            MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenMarioLevel();
        }));
       
    }
}
