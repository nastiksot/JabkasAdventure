using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UI.Base;
using UnityEngine;

namespace UI.DataSaver
{
    [Serializable]
    public static class SaveDataManager
    {
        public static string directoryName = "SaveData";

        public static void SaveData(PlayerData data, string fileName)
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
            
            var file = CreateFile(fileName);

            binaryFormatter.Serialize(file, data);
            file.Close();
        }


        public static PlayerData LoadData(string fileName)
        {
            if (!SaveExists(fileName)) return null;
            try
            {
                var binaryFormatter = new BinaryFormatter();
                var file = OpenFile(fileName);
                var playerData = (PlayerData) binaryFormatter.Deserialize(file);
                file.Close();
                return playerData;
            }
            catch (SerializationException exception)
            {
                ToastUtility.ShowToast($"Failed to load file, reason: {exception}");
            }

            return null;
        }

        private static bool SaveExists(string fileName)
        {
            return File.Exists(GetFullPathFile(fileName));
        }

        private static bool DirectoryExists()
        {
            return Directory.Exists(Application.persistentDataPath + "/" + directoryName);
        }

        private static string GetFullPathFile(string fileName)
        {
            return Application.persistentDataPath + "/" + directoryName + "/" + fileName + ".dat";
        }

        private static FileStream CreateFile(string fileName)
        {
            return File.Create(GetFullPathFile(fileName));
        }

        private static FileStream OpenFile(string fileName)
        {
            return File.Open(GetFullPathFile(fileName), FileMode.Open);
        }
    }
}