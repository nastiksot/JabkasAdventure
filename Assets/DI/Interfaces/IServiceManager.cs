using Services.Data.Interfaces;

namespace DI.interfaces
{
    public interface IServiceManager
    { 
        IDataService GetDataService();
    }
}