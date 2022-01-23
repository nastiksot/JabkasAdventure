using System;

namespace Models.ClassModels
{
    [Serializable]
    public class PlayerData
    {
        private string playerName = "None";
        private int playerHealth = 0;
        private int playerScore = 0;
        private int sheetScore = 0;

        public int SheetScore
        {
            get => sheetScore;
            set => sheetScore = value;
        }

        public string PlayerName
        {
            get => playerName;
            set => playerName = value;
        }

        public int PlayerHealth
        {
            get => playerHealth;
            set => playerHealth = value;
        }

        public int PlayerScore
        {
            get => playerScore;
            set => playerScore = value;
        }

        public PlayerData(PlayerData data)
        {
            playerName = data.PlayerName;
            playerHealth = data.PlayerHealth;
            playerScore = data.PlayerScore;
            sheetScore = data.sheetScore;
        }

        public PlayerData()
        {
        }

        public void UpdateHealth(int health)
        {
            playerHealth = health;
        }

        public void UpdateScore(int score)
        {
            playerScore = score;
        }

        public void UpdateSheetCount(int sheet)
        {
            sheetScore = sheet;
        }
    }
}