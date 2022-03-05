using Models.Enum;
using UnityEngine;

namespace Services.Interfaces
{
    public interface IParticleService
    {
        public void InitializeParticle(RewardType rewardType, Vector3 position);
    }
}