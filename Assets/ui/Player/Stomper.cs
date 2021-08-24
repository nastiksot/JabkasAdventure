using System;
using DI.Services.Constants;
using UI.DataSaver;
using UnityEngine;

namespace UI.Player
{
    public class Stomper : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D parentRigidbody2D;
        [SerializeField] private float bounceForce;
        [SerializeField] private int spiderCost = 10;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.ENEMY_HEAR_TAG)) return;
            Destroy(other.transform.parent.gameObject);
            parentRigidbody2D.AddForce(transform.up*bounceForce,ForceMode2D.Impulse);
            StatisticsDataCollector.Instance.ChangeTotalScoreValueByKilledSpider(spiderCost);
        }
    }
}