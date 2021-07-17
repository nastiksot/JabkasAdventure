using System;
using System.IO;
using Models;
using UI.DataSaver;

namespace Services.Data.Interfaces
{
    public interface IDataService
    {
        public void SaveData(PlayerData data, string fileName);
        public void LoadData(string fileName, Action<PlayerData> success, Action<BaseError> failure); 
        public void CreateFile(string fileName, Action<FileStream> success, Action<BaseError> failure);
        public void OpenFile(string fileName, Action<FileStream> success, Action<BaseError> failure);
    }
}