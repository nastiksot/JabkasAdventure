using System;
using System.IO;
using DI.Models;
using DI.Models.PlayerModel;
using DI.Modules.Data.Intefaces;

namespace DI.Services.Data.Interfaces
{
    public interface IDataService: IBaseService
    {
        public void SaveData(PlayerData data, string fileName);
        public void LoadData(string fileName, Action<PlayerData> success, Action<BaseError> failure); 
        public void CreateFile(string fileName, Action<FileStream> success, Action<BaseError> failure);
        public void OpenFile(string fileName, Action<FileStream> success, Action<BaseError> failure);
        void SetDependency(IDataModule dataModule);
    }
}