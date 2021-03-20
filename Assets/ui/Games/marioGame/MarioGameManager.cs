using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioGameManager : BaseMono
{
    public static MarioGameManager instance;
    [SerializeField]private Transform respawnPoint;

    [SerializeField]
    private GameObject playerObject;

    private void Awake()
    {
        instance = this;
    }

    

 
}
