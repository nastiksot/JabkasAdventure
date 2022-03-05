using System;
using Models.Enum;
using UI.Enemy;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Factory
{
    public class RewardFactory : IRewardFactory
    {
        private readonly DiContainer diContainer;

        private Object spiderPrefab;

        public RewardFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public void Load()
        {
            spiderPrefab = Resources.Load<EnemyBehaviour>( "Spider");
        }

        public void Create(Vector2 position, RewardType enemyType)
        {
            switch (enemyType)
            {
                case RewardType.Spider:
                    diContainer.InstantiatePrefab(spiderPrefab, position, Quaternion.identity, null);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
            }
        }
    }
}