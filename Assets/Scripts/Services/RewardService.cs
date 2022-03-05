using System.Collections.Generic;
using System.Linq;
using Models.Enum;
using Models.ScriptableObjects;
using Services.Interfaces;
using UnityEngine;

namespace Services
{
    public class RewardService : MonoBehaviour, IRewardService
    {
        [SerializeField] private List<RewardCostSO> rewardCostSO;

        public List<RewardCostSO> RewardCostSOs => rewardCostSO;

        public int GetBonusReward(RewardType rewardType)
        {
            return rewardCostSO.First(x => x.RewardType == rewardType).Cost;
        }
    }
}