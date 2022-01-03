using UnityEngine;

namespace Factory
{
    public interface IPlayerFactory
    {
        public void Load();
        public void Create(Vector2 position);
    }
}