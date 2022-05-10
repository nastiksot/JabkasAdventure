using System;
using Models.ClassModels;
using Models.ConstantValues;
using Services.Interfaces;
using TMPro;
using UI;
using UnityEngine;
using Zenject;

namespace Modules
{
    public class FileDataReader : MonoBehaviour
    {
        [SerializeField] private TMP_Text statisticText;
        private IFileService fileService;
        private StatisticModel statisticModel = new StatisticModel();
        private string statisticPattern = "Your score: {0}. \n" +
                                          "CV sheets: {1} / {2}.\n" +
                                          "Defeat spiders {3} / {4}.";
        [Inject]
        private void Construct(IFileService fileService)
        {
            this.fileService = fileService;
        }

        private void Start()
        {
            ReadDataFromFile();
        }

        private void SetTextData()
        {
            statisticText.text = string.Format(statisticPattern,
                statisticModel.Score,
                statisticModel.SheetCount, statisticModel.TotalSheetCount,
                statisticModel.KillCount, statisticModel.TotalEnemyCount);
        }

        private void ReadDataFromFile()
        {
            fileService.LoadData(Constants.SaveFileName, SetStatisticModel, null);
        }

        private void SetStatisticModel(StatisticModel statisticModel)
        {
            this.statisticModel = statisticModel;
            SetTextData();
        }
    }
}