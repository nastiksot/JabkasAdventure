using System.Collections.Generic;
using DI.Interfaces;
using DI.Services;
using DI.Services.Data;
using DI.Services.Data.Interfaces;

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

        /// <summary>
        /// Init data service
        /// </summary>
        /// <param name="moduleManager"></param>
        private void InitDataService(IModuleManager moduleManager)
        {
            dataService = new DataService();
            allServices.Add(dataService);
            dataService.SetDependency(moduleManager.GetDataModule());
        }

        /// <summary>
        /// Get data service
        /// </summary>
        /// <returns></returns>
        public IDataService GetDataService()
        {
            return dataService;
        }
    }
}