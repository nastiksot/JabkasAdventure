using System;
using System.IO;
using Models;
using Models.PlayerModel;
using Services.Data.Interfaces;
using IDataModule = Modules.Data.Intefaces.IDataModule;

namespace Services.Data
{
    public class DataService : IDataService
    {
        private IDataModule dataModule;
 
        public void SetDependency(IDataModule dataModule)
        {
            this.dataModule = dataModule;
        }


        public void SaveData(PlayerData data, string fileName)
        {
            dataModule.SaveData(data, fileName);
        }

        public void LoadData(string fileName, Action<PlayerData> success, Action<BaseError> failure)
        {
            dataModule.LoadData(fileName, success, failure);
        }

        public void CreateFile(string fileName, Action<FileStream> success, Action<BaseError> failure)
        {
            dataModule.CreateFile(fileName, success, failure);
        }

        public void OpenFile(string fileName, Action<FileStream> success, Action<BaseError> failure)
        {
            dataModule.OpenFile(fileName, success, failure);
        }

        public void initWithDependency()
        { 
        }
    }
}