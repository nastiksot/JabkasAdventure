﻿using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Models.ClassModels;
using Models.ConstantValues;
using UnityEngine;
using Utility;

namespace Modules
{
    public class FileModule : IFileModule
    {
        private string directoryName = "SavedData";

        public string DirectoryName
        {
            get => directoryName;
            set => directoryName = value;
        }

        /// <summary>
        /// Save data in file
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        public void SaveData(StatisticModel model, string fileName)
        {
            if (!DirectoryExists())
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/" + directoryName);
            }

            var binaryFormatter = new BinaryFormatter();

            if (File.Exists(GetFullPathFile(fileName)))
            {
                File.Delete(fileName);
            }

            CreateFile(fileName, fileStream =>
                {
                    binaryFormatter.Serialize(fileStream, model);
                    fileStream.Close();
                }, error => { ToastUtility.ShowToast(error.errorMessage); }
            );
        }

        /// <summary>
        /// Load data from file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void LoadData(string fileName, Action<StatisticModel> success, Action<BaseError> failure)
        {
            if (!SaveExists(fileName))
            {
                failure?.Invoke(new BaseError(BaseErrorCode.FAIL_LOAD_DATA, "File does not exists"));
            }

            try
            {
                var binaryFormatter = new BinaryFormatter();
                OpenFile(fileName, fileStream =>
                {
                    var playerData = (StatisticModel) binaryFormatter.Deserialize(fileStream);
                    fileStream.Close();
                    success?.Invoke(playerData);
                }, failure);
            }
            catch (SerializationException exception)
            {
                ToastUtility.ShowToast($"Failed to load file, reason: {exception}");
            }
        }

        /// <summary>
        /// Rewrite data in exists file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool SaveExists(string fileName)
        {
            return File.Exists(GetFullPathFile(fileName));
        }

        /// <summary>
        /// Check is directory exists
        /// </summary>
        /// <returns></returns>
        public bool DirectoryExists()
        {
            return Directory.Exists(Application.persistentDataPath + "/" + directoryName);
        }

        /// <summary>
        /// Get full path file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetFullPathFile(string fileName)
        {
            return Application.persistentDataPath + "/" + directoryName + "/" + fileName + ".dat";
        }

        /// <summary>
        /// Create file for saving data
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void CreateFile(string fileName, Action<FileStream> success, Action<BaseError> failure)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                failure?.Invoke(new BaseError(BaseErrorCode.FAIL_CREATE_FILE, "File name is empty"));
            }
            else
            {
                success?.Invoke(File.Create(GetFullPathFile(fileName)));
            }
        }

        /// <summary>
        /// Open data file 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public void OpenFile(string fileName, Action<FileStream> success, Action<BaseError> failure)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                failure?.Invoke(new BaseError(BaseErrorCode.FAIL_OPEN_FILE, "File name is empty"));
            }
            else
            {
                success?.Invoke(File.Open(GetFullPathFile(fileName), FileMode.Open));
            }
        }
    }
}