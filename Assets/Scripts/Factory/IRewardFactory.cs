using Models.Enum;
using UnityEngine;

namespace Factory
{
    public interface IRewardFactory
    {
        public void Load();
        public void Create(Vector2 position, RewardType rewardType);
    }
}