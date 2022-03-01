using System;
using UI.Enemy;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly DiContainer diContainer;

        private Object spiderPrefab;

        public EnemyFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public void Load()
        {
            spiderPrefab = Resources.Load<EnemyBehaviour>( "Spider");
        }

        public void Create(Vector2 position, EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.Spider:
                    diContainer.InstantiatePrefab(spiderPrefab, position, Quaternion.identity, null);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
            }
        }

        public void Unload()
        {
            Resources.UnloadAsset(spiderPrefab);
        }
        
    }
}