 
using Models;
using Models.ConstantValues;
using UnityEngine;
using Utility;

namespace UI.Player
{
    public class Stomper : MonoBehaviour
    {
        [SerializeField] private GameObject enemyDeathParticle;
        [SerializeField] private Rigidbody2D parentRigidbody2D;
        [SerializeField] private float bounceForce;

        private GameObject enemyParticle; 

       
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag(Tags.ENEMY_HEAR_TAG)) return;  
            InitializeDeathParticle(other.transform.position);
            Destroy(other.transform.parent.gameObject);
            parentRigidbody2D.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
            // StatisticsDataCollector.Instance.ChangeTotalScore(spiderCost);
        }

        /// <summary>
        /// On player death initialize particle
        /// </summary>
        /// <param name="particlePosition"></param>
        private void InitializeDeathParticle(Vector3 particlePosition)
        {
            enemyParticle = Instantiate(enemyDeathParticle, null, true);
            enemyParticle.transform.position = particlePosition;
            StartCoroutine(ExtensionUtility.StartWithDelay(1f, () => Destroy(enemyParticle)));
        }

        
    }
}