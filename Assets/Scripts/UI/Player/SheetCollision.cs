using Models;
using Models.ConstantValues;
using Models.Enum;
using UI.DataSaver;
using UI.Timer;
using UnityEngine;
using Zenject;

namespace UI.Player
{
    public class SheetCollision : MonoBehaviour
    { 
        private Rigidbody2D rigidbody2D;
        private StatisticsCollector statisticsCollector;
        
        [Inject]
        public void Construct(StatisticsCollector statisticsCollector)
        {
            this.statisticsCollector = statisticsCollector;
        }
        
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
                statisticsCollector.ChangeScore(BonusType.Sheet);
            Destroy(gameObject);
        }
    }
}