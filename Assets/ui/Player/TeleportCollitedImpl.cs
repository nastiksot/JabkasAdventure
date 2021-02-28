using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCollitedImpl : BaseMono, TeleportCollited
{
    [SerializeField] private GameObject sceneDestroyer;

    TeleportCollitedImpl()
    {
        TAG = "TeleportCollitedImpl";
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<PlayerBehaviourImpl>())
        {
            dlog("Collited and destroyed!");
            //Destroy(sceneDestroyer);
        }
    }
}