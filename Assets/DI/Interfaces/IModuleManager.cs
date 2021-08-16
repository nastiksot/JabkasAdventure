using DI.Modules.Data.Intefaces;

namespace DI.Interfaces
{
    public interface IModuleManager
    {
        IDataModule GetDataModule();
    }
}