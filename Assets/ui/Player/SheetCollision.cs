using System;
using services.Constants;
using UI.DataSaver;
using UnityEngine;

namespace UI.Player
{
    public class SheetCollision : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private int sheetCosts = 10;

        private void Start()
        {
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == Layers.GROUND_LAYER)
            {
                rigidbody2D.bodyType = RigidbodyType2D.Static;
            }

            if (!other.gameObject.CompareTag("Player")) return;
            Destroy(gameObject);
            StatisticsDataCollector.Instance.ChangeSheetScoreValue(sheetCosts);
        }
    }
}