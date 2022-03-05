using System;
using Models.ClassModels;

namespace Services.Interfaces
{
    public interface IStatisticService
    {
        public event Action<int> OnScoreChanged;
        public event Action<int> OnSheetAdded;
        public void AddScore(int score);
        public void AddSheet(int score);
        public void AddKill(int score);
        public StatisticModel GetStatisticModel();
    }
}