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
        }

        private void InitializeBonusSheet(Vector3 position)
        {
            var instantiatedSheet = Instantiate(sheetPrefab, position + Vector3.up * 2, Quaternion.identity, transform);
            instantiatedSheet.OnSheetCollided += () => statisticService.AddSheet();
        }
    }
}