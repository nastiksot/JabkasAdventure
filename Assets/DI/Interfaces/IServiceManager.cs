using DI.Services.Data.Interfaces;

namespace DI.Interfaces
{
    public interface IServiceManager
    { 
        IDataService GetDataService();
    }
}