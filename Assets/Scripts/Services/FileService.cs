using System;
using System.IO;
using Models.ClassModels;
using Modules;
using Services.Interfaces; 

namespace Services
{
    public class FileService : IFileService
    {
        private IFileModule fileModule = new FileModule();
 
        /// <summary>
        /// Save data in file
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        public void SaveData(StatisticModel model, string fileName)
        {
            fileModule.SaveData(model, fileName);
        }

        /// <summary>
        /// Load data from file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void LoadData(string fileName, Action<StatisticModel> success, Action<BaseError> failure)
        {
            fileModule.LoadData(fileName, success, failure);
        }

        /// <summary>
        /// Create file for saving data
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void CreateFile(string fileName, Action<FileStream> success, Action<BaseError> failure)
        {
            fileModule.CreateFile(fileName, success, failure);
        }

        /// <summary>
        /// Open data file 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void OpenFile(string fileName, Action<FileStream> success, Action<BaseError> failure)
        {
            fileModule.OpenFile(fileName, success, failure);
        }
    }
}