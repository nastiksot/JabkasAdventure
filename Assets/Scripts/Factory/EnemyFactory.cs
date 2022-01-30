using UI.Player; 
using UnityEngine;
using Zenject;

namespace Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly DiContainer diContainer;

        private Object enemyPrefab;

        public EnemyFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public void Load()
        {
            enemyPrefab = Resources.Load( "");
        }

        public void Create(Vector2 position)
        {
           diContainer.InstantiatePrefab(enemyPrefab, position, Quaternion.identity, null);
        }

        public void Unload()
        {
            Resources.UnloadAsset(enemyPrefab);
        }
    }
}