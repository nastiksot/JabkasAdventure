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
        Init();
    }

    public void Init()
    {
        playButton.setOnClickListener(() => { MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenIntroLevel(); });
#if PLATFORM_ANDROID
        settingsButton.setOnClickListener(Application.Quit);
#endif
    }
}