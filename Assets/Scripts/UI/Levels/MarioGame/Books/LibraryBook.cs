using System.Collections;
using Models.ConstantValues;
using Models.Enum;
using UI.DataSaver;
using UnityEngine;
using Zenject;

namespace UI.Levels.MarioGame.Books
{
    public class LibraryBook : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer blockSprite;
        [SerializeField] private Sprite emptyShelfSprite;

        [Space(6f), Header("Prefab")]
        [SerializeField]
        private CVSheet CVSheetPrefab;

        private bool isContainSheet = true;
        private bool isShelfClosed = true;


        private StatisticsCollector statisticsCollector;
        private CVSheet instantiatedCVSheet;

        [Inject]
        private void Construct(StatisticsCollector statisticsCollector)
        {
            this.statisticsCollector = statisticsCollector;
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.bounds.max.y < transform.position.y &&
                col.collider.bounds.min.x < transform.position.x + 0.3f &&
                col.collider.bounds.min.x < transform.position.x - 0.3f &&
                col.gameObject.CompareTag(Tags.PLAYER_TAG))
            {
                if (isContainSheet)
                {
                    //TODO: init sound hit block; 
                    isContainSheet = false;
                }

                if (isContainSheet) return;
                StartCoroutine(InitializeBonusSheet());
                blockSprite.sprite = emptyShelfSprite;
            }
        }

        private IEnumerator InitializeBonusSheet()
        {
            yield return new WaitForSeconds(0.17f);
            if (!isShelfClosed) yield break;
            instantiatedCVSheet = Instantiate(CVSheetPrefab, transform.position + Vector3.up * 2, Quaternion.identity);
            instantiatedCVSheet.OnPlayerCollided += () =>
            {
                statisticsCollector.ChangeScore(BonusType.Sheet);
                Destroy(instantiatedCVSheet.gameObject);
            };
            isShelfClosed = false;
        }
    }
}