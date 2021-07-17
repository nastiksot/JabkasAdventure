using Services.Data.Interfaces;
using Services.Navigator.interfaces;

namespace DI.interfaces
{
    public interface IServiceManager
    {
        IMainNavigatorServices GetMainNavigatorService();
        IDataService GetDataService();
    }
}