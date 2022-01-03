using Models;
using UnityEngine;

namespace UI.Player
{
    public class SheetCollision : MonoBehaviour
    {
        [SerializeField] private int sheetCosts = 10;
        private Rigidbody2D rigidbody2D;

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == Layers.GROUND_LAYER)
            {
                rigidbody2D.bodyType = RigidbodyType2D.Static;
            }

            if (!other.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            Destroy(gameObject);
            // StatisticsDataCollector.Instance.ChangeSheetScoreValue(sheetCosts);
        }
    }
}