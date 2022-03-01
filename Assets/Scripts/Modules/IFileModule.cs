using System;
using System.IO;
using Models;
using Models.ClassModels;

namespace Modules
{
    public interface IFileModule
    {
        /// <summary>
        /// Save data in file
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        void SaveData(StatisticModel model, string fileName);

        /// <summary>
        /// Load data from file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        void LoadData(string fileName, Action<StatisticModel> success, Action<BaseError> failure);

        /// <summary>
        /// Rewrite data in exists file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool SaveExists(string fileName);

        /// <summary>
        /// Check is directory exists
        /// </summary>
        /// <returns></returns>
        bool DirectoryExists();

        /// <summary>
        /// Get full path file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string GetFullPathFile(string fileName);

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