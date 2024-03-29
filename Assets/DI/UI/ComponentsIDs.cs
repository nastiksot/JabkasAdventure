﻿using System;

namespace DI.UI
{
    [Flags]
    public enum ComponentsIDs
    {
        Player,
        MainMenu,
        IntroLevel,
        MainLevel,
        FinalLevel,
        LoadingScreen,
        NavigationMenu,
        PauseMenu,
        GameOverMenu,
        StatisticsData
    }
}