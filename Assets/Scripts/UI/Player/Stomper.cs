using Models.ConstantValues;
using Services.Interfaces;
using UI.Enemy;
using UnityEngine;
using Zenject;

namespace UI.Player
{
    public class Stomper : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D parentRigidbody2D;
        [SerializeField] private float bounceForce;

        private IParticleService particleService;
        private IStatisticService statisticService;
        private IRewardService rewardService;

        [Inject]
        private void Construct(IParticleService particleService, IStatisticService statisticService,
            IRewardService rewardService)
        {
            this.particleService = particleService;
            this.statisticService = statisticService;
            this.rewardService = rewardService;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var collidedGameObject = other.gameObject;
            if (!collidedGameObject.CompareTag(Tags.ENEMY_HEAR_TAG)) return;
            var enemyObject = collidedGameObject.GetComponentInParent<EnemyBehaviour>();
            var rewardType = enemyObject.RewardType;
            enemyObject.OnEnemyDestroyed += () =>
            {
                var reward = rewardService.GetBonusReward(rewardType);
                statisticService.AddKill(reward);
                particleService.InitializeParticle(rewardType, enemyObject.transform.position);
            };

            enemyObject.DestroyEnemy();
            parentRigidbody2D.velocity = transform.up * bounceForce;
        }
    }
}