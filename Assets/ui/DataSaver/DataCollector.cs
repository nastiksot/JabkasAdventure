using System;
using TMPro;
using UnityEngine;

namespace UI.DataSaver
{
    public class DataCollector : MonoBehaviour
    {
        [SerializeField] private TMP_Text sheetScore;
        
        private PlayerData playerData;
        private string filePath = "DefaultSave";

        public string FilePath
        {
            get => filePath;
            set => filePath = value;
        }

        public void OnDataChanged(PlayerData data)
        {
            playerData = new PlayerData()
            {
                PlayerHealth = data.PlayerHealth,
                PlayerScore = data.PlayerScore,
                PlayerName = data.PlayerName
            };
        }

        public void CreateSaveDataFile()
        {
            SaveDataManager.SaveData(playerData, filePath);
        }

        public PlayerData LoadDataFile()
        {
            return SaveDataManager.LoadData(filePath);
        }
    }
}