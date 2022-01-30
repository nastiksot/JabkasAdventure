using UnityEngine;

namespace Factory
{
    public interface IEnemyFactory
    {
        public void Load();
        public void Create(Vector2 position);
        public void Unload();
    }
}