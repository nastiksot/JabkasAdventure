using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDependencyImpl : MainDependencys
{
    private static MainDependencys instance = new MainDependencyImpl();
    private ServiceManager serviceManager;
     
    public MainDependencyImpl()
    {
        serviceManager = new ServiceManagerImpl();
    }

    public static MainDependencys getInstance()
    {
        return instance;
    }

    public ServiceManager GetServiceManager()
    {
        return serviceManager;
    }
}
