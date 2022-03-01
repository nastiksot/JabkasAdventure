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


        public StatisticModel(StatisticModel model)
        {
            name = model.Name;
            health = model.Health;
            score = model.Score;
            sheetCount = model.SheetCount;
        }

        public StatisticModel()
        {
        }

    }
}