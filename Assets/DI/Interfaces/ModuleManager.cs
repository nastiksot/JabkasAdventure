using DI.Modules.Data;
using DI.Modules.Data.Intefaces;

namespace DI.Interfaces
{
    public class ModuleManager : IModuleManager
    {
        private IDataModule dataModule = new DataModule();

        public IDataModule GetDataModule()
        {
            return dataModule;
        }
    }
}