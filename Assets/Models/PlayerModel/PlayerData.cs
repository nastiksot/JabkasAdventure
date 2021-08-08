using System;

namespace Models.PlayerModel
{
    [Serializable]
    public class PlayerData
    {
        private string playerName = "None";
        private int playerHealth = 0;
        private int playerScore = 0;

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

        public PlayerData( PlayerData data)
        {
            playerName = data.PlayerName;
            playerHealth = data.PlayerHealth;
            playerScore = data.PlayerScore;
        }

        public PlayerData()
        {
        }
    }
}