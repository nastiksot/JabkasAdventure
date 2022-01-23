using System;
using System.IO;
using Models;
using Models.ClassModels;
using Modules;

namespace Services.Interfaces
{
    public interface IDataService
    {  
        /// <summary>
        /// Save data in file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        void SaveData(PlayerData data, string fileName);

        /// <summary>
        /// Load data from file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        void LoadData(string fileName, Action<PlayerData> success, Action<BaseError> failure);

        /// <summary>
        /// Create file for saving data
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        void CreateFile(string fileName, Action<FileStream> success, Action<BaseError> failure);

        /// <summary>
        /// Open data file 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        void OpenFile(string fileName, Action<FileStream> success, Action<BaseError> failure);
    }
}