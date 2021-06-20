using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroGameManagerImpl : BaseMono
{
    [SerializeField] private NewsStandImpl newsStandObject;
    [SerializeField] private MessagePanelImpl messagePanelObject;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        newsStandObject.OnStandCollited(() => { messagePanelObject.OpenPanel(); });
    }
}