using System;
using Models.ClassModels;

namespace Services.Interfaces
{
    public interface IStatisticService
    {
        public event Action<int> OnScoreChanged;
        public event Action<int> OnSheetAdded;
        public void AddScore(int score);
        public void AddSheet();
        public StatisticModel GetStatisticModel();
    }
}