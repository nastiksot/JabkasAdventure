using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCollitedImpl : BaseMono
{
    private TeleportCollitedImpl()
    {
        TAG = "TeleportCollitedImpl";
    }
 

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
        dlog("Collited and destroyed!"); 
        //GetComponent<AudioSource>().Play();
        MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenMarioGame();
    }
}