using Modules.Data.Intefaces;

namespace DI.interfaces
{
    public interface IModuleManager
    {
        IDataModule GetDataModule();
    }
}