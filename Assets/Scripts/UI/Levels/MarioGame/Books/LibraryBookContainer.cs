using System.Collections.Generic;
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

        [Inject]
        private void Construct(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }

        private void Awake()
        {
            for (var i = 0; i < libraryBooks.Count; i++)
            {
                var t = i;
                libraryBooks[t].OnBlockCollided += InitializeBonusSheet;
            }

            for (var i = 0; i < bonusSheets.Count; i++)
            {
                var t = i;
                bonusSheets[t].OnSheetCollided += AddSheetOnSheetCollision;
            }
        }

        private void AddSheetOnSheetCollision(BonusSheet bonusSheet)
        {
            bonusSheets.Remove(bonusSheet);
            statisticService.AddSheet();
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