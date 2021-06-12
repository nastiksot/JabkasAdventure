using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : BaseMono
{
  private void Start()
  {
    MainDependencyImpl.getInstance().GetServiceManager().GetMainNavigatorService().GetMenuNavigatorService().OpenMainMenu();
  }
}
