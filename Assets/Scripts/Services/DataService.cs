using System;
using System.IO;
using Models.ClassModels;
using Modules;
using Services.Interfaces; 

namespace Services
{
    public class DataService : IDataService
    {
        private IDataModule dataModule = new DataModule();
 
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
    }
}