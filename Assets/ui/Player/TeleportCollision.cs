using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCollision : BaseMono
{
    private TeleportCollision()
    {
        TAG = "TeleportCollision";
    }


    private void OnTriggerEnter2D
        (Collider2D col)
    {
        if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
        dlog("Collited and destroyed!");
        //GetComponent<AudioSource>().Play();
        //MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenMarioLevel();
    }
}