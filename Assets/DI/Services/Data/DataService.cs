using System;
using System.IO;
using DI.Models;
using DI.Models.PlayerModel;
using DI.Services.Data.Interfaces;
using IDataModule = DI.Modules.Data.Intefaces.IDataModule;

namespace DI.Services.Data
{
    public class DataService : IDataService
    {
        private IDataModule dataModule;
 
        public void SetDependency(IDataModule dataModule)
        {
            this.dataModule = dataModule;
        }
        
        /// <summary>
        /// Save data in file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        public void SaveData(PlayerData data, string fileName)
        {
            dataModule.SaveData(data, fileName);
        }

        /// <summary>
        /// Load data from file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void LoadData(string fileName, Action<PlayerData> success, Action<BaseError> failure)
        {
            dataModule.LoadData(fileName, success, failure);
        }

        /// <summary>
        /// Create file for saving data
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void CreateFile(string fileName, Action<FileStream> success, Action<BaseError> failure)
        {
            dataModule.CreateFile(fileName, success, failure);
        }

        /// <summary>
        /// Open data file 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void OpenFile(string fileName, Action<FileStream> success, Action<BaseError> failure)
        {
            dataModule.OpenFile(fileName, success, failure);
        }

        public void initWithDependency()
        { 
        }
    }
}