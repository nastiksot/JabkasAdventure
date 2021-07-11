using System.Collections;
using System.Collections.Generic;
using DI;
using DI.interfaces;
using UnityEngine;

public class MainDependency : IMainDependencys
{
    private static IMainDependencys instance = new MainDependency();
    private IServiceManager serviceManager;
     
    public MainDependency()
    {
        serviceManager = new ServiceManager();
    }

    public static IMainDependencys GetInstance()
    {
        return instance;
    }

    public IServiceManager GetServiceManager()
    {
        return serviceManager;
    }
}
