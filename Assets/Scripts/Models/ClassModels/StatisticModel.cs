using System;

namespace Models.ClassModels
{
    [Serializable]
    public class StatisticModel
    {
        private string name = "Player";
        private int health = 0;
        private int score = 0;
        private int sheetCount = 0;
        private int totalSheetCount = 0;
        private int killCount = 0;
        private int totalEnemyCount = 0;

        public string Name => name;
        public int Health => health;

        public int Score
        {
            get => score;
            set => score = value;
        }

        public int SheetCount
        {
            get => sheetCount;
            set => sheetCount = value;
        }

        public int KillCount
        {
            get => killCount;
            set => killCount = value;
        }
        
        public int TotalSheetCount
        {
            get => totalSheetCount;
            set => totalSheetCount = value;
        }

        public int TotalEnemyCount
        {
            get => totalEnemyCount;
            set => totalEnemyCount = value;
        }
        
        public StatisticModel()
        {
        }
    }
}