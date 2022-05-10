using Models.Enum;
using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BonusCost", menuName = "ScriptableObjects/BonusCost", order = 1)]
    public class RewardCostSO : ScriptableObject
    {
        [SerializeField] private RewardType rewardType;
        [SerializeField] private int cost;

        public RewardType RewardType => rewardType;
        public int Cost => cost;
    }
}