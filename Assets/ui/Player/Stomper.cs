using System;
using DI;
using DI.Services.Constants;
using UI.Base;
using UI.DataSaver;
using UI.Games;
using UnityEngine;

namespace UI.Player
{
    public class Stomper : BaseMono
    {
        [SerializeField] private GameObject particleHolder;
        [SerializeField] private GameObject enemyDeathParticle;
        [SerializeField] private Rigidbody2D parentRigidbody2D;
        [SerializeField] private float bounceForce;
        [SerializeField] private int spiderCost = 10;

        private GameObject enemyParticle;
        private LevelManager levelManager;

        private void Start()
        {
            GetLevelManger();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.ENEMY_HEAR_TAG)) return;
            InitializeDeathParticle(other);
            Destroy(other.transform.parent.gameObject);
            parentRigidbody2D.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
            StatisticsDataCollector.Instance.ChangeTotalScore(spiderCost);
        }

        /// <summary>
        /// On player death initialize particle
        /// </summary>
        /// <param name="other"></param>
        private void InitializeDeathParticle(Collider2D other)
        {
            enemyParticle = Instantiate(enemyDeathParticle, levelManager.transform, true);
            enemyParticle.transform.position = other.transform.position;
            StartCoroutine(startWithDelay(1f, () => Destroy(enemyParticle)));
        }

        /// <summary>
        /// Get level manager
        /// </summary>
        private void GetLevelManger()
        {
            MainDependency.GetInstance().GetGameManager().GetLevelManager(manager => { levelManager = manager;},
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }
    }
}