using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuImpl : BaseMono, MainMenu
{
    [SerializeField] private GameObject playObject;
    [SerializeField] private GameObject mapObject;
    [SerializeField] private GameObject settingsObject;
    private ClickButton playClickButton;
    private ClickButton mapClickButton;
    private ClickButton settingsClickButton;

    private void Start()
    {
        init();
    }

    public void init()
    {
        playClickButton = playObject.GetComponent<ClickButtonImpl>();
        mapClickButton = mapObject.GetComponent<ClickButtonImpl>();
        settingsClickButton = settingsObject.GetComponent<ClickButtonImpl>();
        playClickButton.setOnClickListener(() =>
        {
            MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().openIntroGame();
        });
        mapClickButton.setOnClickListener(() =>
        {
            dlog("Map");
        });
        settingsClickButton.setOnClickListener(() =>
        {
            dlog("Settings");
        });
    }
}