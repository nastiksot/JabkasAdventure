using UI.Levels;
using UnityEngine;

namespace Factory
{
    public interface IEnemyFactory
    {
        public void Load();
        public void Create(Vector2 position, EnemyType enemyType);
        public void Unload();
    }
}