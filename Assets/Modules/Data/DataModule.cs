using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Models;
using Modules.Data.Intefaces;
using UI.Base;
using UI.DataSaver;
using UnityEngine;

namespace Modules.Data
{
    public class DataModule : IDataModule
    {
        private static string directoryName = "SaveData";

        public static string DirectoryName
        {
            get => directoryName;
            set => directoryName = value;
        }

        public void SaveData(PlayerData data, string fileName)
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
                    binaryFormatter.Serialize(fileStream, data);
                    fileStream.Close();
                }, error => { ToastUtility.ShowToast(error.errorMessage); }
            );
        }


        public void LoadData(string fileName, Action<PlayerData> success, Action<BaseError> failure)
        {
            if (!SaveExists(fileName))
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_LOAD_DATA, "File does not exists"));
            }

            try
            {
                var binaryFormatter = new BinaryFormatter();
                OpenFile(fileName, fileStream =>
                {
                    var playerData = (PlayerData) binaryFormatter.Deserialize(fileStream);
                    fileStream.Close();
                    success?.Invoke(playerData);
                }, failure);
            }
            catch (SerializationException exception)
            {
                ToastUtility.ShowToast($"Failed to load file, reason: {exception}");
            }
        }

        public bool SaveExists(string fileName)
        {
            return File.Exists(GetFullPathFile(fileName));
        }

        public bool DirectoryExists()
        {
            return Directory.Exists(Application.persistentDataPath + "/" + directoryName);
        }

        public string GetFullPathFile(string fileName)
        {
            return Application.persistentDataPath + "/" + directoryName + "/" + fileName + ".dat";
        }

        public void CreateFile(string fileName, Action<FileStream> success, Action<BaseError> failure)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_CREATE_FILE, "File name is empty"));
            }
            else
            {
                success?.Invoke(File.Create(GetFullPathFile(fileName)));
            }
        }

        public void OpenFile(string fileName, Action<FileStream> success, Action<BaseError> failure)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                failure?.Invoke(new BaseError(BaseError.FAIL_OPEN_FILE, "File name is empty"));
            }
            else
            {
                success?.Invoke(File.Open(GetFullPathFile(fileName), FileMode.Open));
            }
        }
    }
}