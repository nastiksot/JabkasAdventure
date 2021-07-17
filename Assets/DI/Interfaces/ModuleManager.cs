using Modules.Data;
using Modules.Data.Intefaces;

namespace DI.interfaces
{
    public class ModuleManager : IModuleManager
    {
        private IDataModule dataModule = new  DataModule();
        
        public IDataModule GetDataModule()
        {
            return dataModule;
        }
    }
}