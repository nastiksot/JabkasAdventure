using System.Collections.Generic;
using Models.Enum;
using Services.Interfaces;
using UnityEngine;
using Zenject;

namespace UI.Levels.MarioGame.Books
{
    public class LibraryBookContainer : MonoBehaviour
    {
        [Header("Prefabs")] [SerializeField] private BonusSheet sheetPrefab;
        [SerializeField] private List<LibraryBook> libraryBooks;
        [SerializeField] private List<BonusSheet> bonusSheets;

        private IStatisticService statisticService;
        private IRewardService rewardService;

        [Inject]
        private void Construct(IStatisticService statisticService, IRewardService rewardService)
        {
            this.statisticService = statisticService;
            this.rewardService = rewardService;
        }

        private void Awake()
        {
            var libraryBookCount = libraryBooks.Count;
            var bonusSheetCount = bonusSheets.Count;
            
            statisticService.AddTotalSheetCount(libraryBookCount + bonusSheetCount);
            
            for (var i = 0; i < libraryBookCount; i++)
            {
                var t = i;
                libraryBooks[t].OnBlockCollided += InitializeBonusSheet;
            }

            for (var i = 0; i < bonusSheetCount; i++)
            {
                var t = i;
                bonusSheets[t].OnSheetCollided += AddSheetOnSheetCollision;
            }
        }

        private void AddSheetOnSheetCollision(BonusSheet bonusSheet)
        {
            bonusSheets.Remove(bonusSheet);
            var reward = rewardService.GetBonusReward(RewardType.Sheet);
            statisticService.AddSheet(reward);
        }

        private void InitializeBonusSheet(Vector3 position)
        {
            var instantiatedSheet = Instantiate(sheetPrefab, position + Vector3.up, Quaternion.identity, transform);
            instantiatedSheet.OnSheetCollided += AddSheetOnSheetCollision;
            bonusSheets.Add(instantiatedSheet);
        }

        private void OnDestroy()
        {
            for (var i = 0; i < libraryBooks.Count; i++)
            {
                libraryBooks[i].OnBlockCollided -= InitializeBonusSheet;
            }

            for (var i = 0; i < bonusSheets.Count; i++)
            {
                bonusSheets[i].OnSheetCollided -= AddSheetOnSheetCollision;
            }
        }
    }
}