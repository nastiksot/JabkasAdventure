using System.Collections.Generic;
using DI.interfaces;
using DI.Services;
using Services.Data;
using Services.Data.Interfaces; 

namespace DI
{
    public class ServiceManager : IServiceManager
    { 
        private IDataService dataService;
        private List<IBaseService> allServices = new List<IBaseService>();

        public ServiceManager(IModuleManager moduleManager)
        {
            InitDataService(moduleManager);
            
            foreach (var baseService in allServices)
            {
                baseService.initWithDependency();
            }
        }

        private void InitDataService(IModuleManager moduleManager)
        {
            dataService = new DataService();
            allServices.Add(dataService);
            dataService.SetDependency(moduleManager.GetDataModule());

        }

        public IDataService GetDataService()
        {
            return dataService;
        }
    }
}