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
        
        [Inject]
        private void Construct(IParticleService particleService)
        {
            this.particleService = particleService;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var collidedGameObject = other.gameObject;
            if (!collidedGameObject.CompareTag(Tags.ENEMY_HEAR_TAG)) return;
            var enemyObject = collidedGameObject.GetComponentInParent<EnemyBehaviour>();
            enemyObject.OnEnemyDestroyed += () =>
                particleService.InitializeParticle(enemyObject.ParticleType, enemyObject.transform.position);
            enemyObject.DestroyEnemy();
            //TODO: Find best way to add force
            parentRigidbody2D.AddRelativeForce(transform.up * bounceForce,ForceMode2D.Force);
        }
    }
}