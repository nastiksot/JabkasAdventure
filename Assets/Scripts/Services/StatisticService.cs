﻿using System;
using Models.ClassModels;
using Services.Interfaces;

namespace Services
{
    public class StatisticService : IStatisticService
    {
        private StatisticModel statisticModel = new StatisticModel();
        public event Action<int> OnScoreChanged;
        public event Action<int> OnSheetAdded;

        public void AddScore(int score)
        {
            var newScore = statisticModel.Score + score;
            statisticModel.Score = newScore;
            OnScoreChanged?.Invoke(newScore);
        }

        public void AddSheet(int score)
        {
            var newSheetNum = statisticModel.SheetCount + 1;
            statisticModel.SheetCount = newSheetNum;
            AddScore(score);
            OnSheetAdded?.Invoke(newSheetNum);
        }

        public void AddKill(int score)
        {
            statisticModel.KillCount++;
            AddScore(score);
        }

        public StatisticModel GetStatisticModel()
        {
            return statisticModel;
        }
    }
}