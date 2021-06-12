using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuImpl : BaseMono, MainMenu
{
    [SerializeField] private ClickButtonImpl playButton;
    [SerializeField] private ClickButtonImpl settingsButton;

    private void Start()
    {
        init();
    }

    public void init()
    {
        playButton.setOnClickListener(() => { MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenIntroGame(); });
        settingsButton.setOnClickListener(() => { dlog("Exit"); });
    }
}