using UnityEngine;
using Zenject;

namespace Factory
{
    public interface IEnemyFactory
    {
        public void Load();
        public void Create(Vector2 position, EnemyType enemyType);
        public void Unload();
    }
}