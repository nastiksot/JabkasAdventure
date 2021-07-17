using System.Collections;
using System.Collections.Generic;
using DI;
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
            MainDependency.GetInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenMarioLevel();
        }));
       
    }
}
