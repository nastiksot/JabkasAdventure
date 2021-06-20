using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroGameManagerImpl : BaseMono
{
    [SerializeField] private NewsStand newsStandObject;
    [SerializeField] private MessagePanel messagePanelObject;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        newsStandObject.OnStandCollited(() => { messagePanelObject.OpenPanel(); });
    }
}