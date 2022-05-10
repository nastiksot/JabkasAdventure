using Models.ConstantValues;
using Services.Interfaces;
using UI;
using UI.DataSaver;
using UnityEngine;
using Zenject;

public class FileDataSaver : MonoBehaviour
{
    [SerializeField] private Teleport teleport;
    [SerializeField] private UIStatistic uiStatistic;
    
    private IStatisticService statisticService;
    private IFileService fileService;
    

    [Inject]
    private void Construct(IStatisticService statisticService, IFileService fileService)
    {
        this.fileService = fileService;
        this.statisticService = statisticService;
    }

    private void OnEnable()
    {
        teleport.OnTeleportCollision += SaveDataToFile;
    }

    private void OnDisable()
    {
        teleport.OnTeleportCollision -= SaveDataToFile;
    }

    private void SaveDataToFile()
    {
        var timeLeft = (int) uiStatistic.TimeLeft;
        statisticService.AddScore(timeLeft);
        var model = statisticService.GetStatisticModel();
        fileService.SaveData(model, Constants.SaveFileName);
    }
}