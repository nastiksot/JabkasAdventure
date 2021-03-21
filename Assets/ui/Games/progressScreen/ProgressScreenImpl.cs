using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressScreenImpl : BaseMono
{
    void Start()
    {
        openMarioGame();
    }

    void openMarioGame()
    {
        StartCoroutine( startWithDelay(6,()=>
        {
            MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().openMarioGame();
        }));
       
    }
}
