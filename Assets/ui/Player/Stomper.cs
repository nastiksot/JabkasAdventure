using System;
using DI;
using DI.Services.Constants;
using UI.Base;
using UI.DataSaver;
using UI.Games;
using UI.Games.MarioGame;
using UnityEngine;

namespace UI.Player
{
    public class Stomper : BaseMono
    {
        [SerializeField] private GameObject enemyDeathParticle;
        [SerializeField] private Rigidbody2D parentRigidbody2D;
        [SerializeField] private float bounceForce;
        [SerializeField] private int spiderCost = 10;

        private GameObject enemyParticle;
        private MarioLevel marioLevel;

       
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.ENEMY_HEAR_TAG)) return;
            //TODO: Add level interface for detection current level 
            if (marioLevel==null)
            {
                GetMarioGame();
            }
            InitializeDeathParticle(other.transform.position);
            Destroy(other.transform.parent.gameObject);
            parentRigidbody2D.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
            StatisticsDataCollector.Instance.ChangeTotalScore(spiderCost);
        }

        /// <summary>
        /// On player death initialize particle
        /// </summary>
        /// <param name="particlePosition"></param>
        private void InitializeDeathParticle(Vector3 particlePosition)
        {
            enemyParticle = Instantiate(enemyDeathParticle, marioLevel.ParticleHolder, true);
            enemyParticle.transform.position = particlePosition;
            StartCoroutine(startWithDelay(1f, () => Destroy(enemyParticle)));
        }

        /// <summary>
        /// Get mario game script
        /// </summary>
        private void GetMarioGame()
        {
            MainDependency.GetInstance().GetReferenceManager().GetMarioLevel(level => { marioLevel = level; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }
    }
}