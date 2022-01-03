using UnityEngine;
using Zenject;

namespace Factory
{
    public class PlayerFactory : IPlayerFactory
    {
        private Object playerPrefab;
        private readonly DiContainer diContainer;

        public PlayerFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;
        }

        public void Load()
        {
            playerPrefab = Resources.Load("Prefab\\Player");
        }

        public void Create(Vector2 position)
        {
            diContainer.InstantiatePrefab(playerPrefab, position, Quaternion.identity, null);
        }
    }
}