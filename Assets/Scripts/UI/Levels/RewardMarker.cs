using Models.Enum;
using UnityEngine;

namespace UI.Levels
{
    public class RewardMarker : MonoBehaviour
    {
        [SerializeField] private Transform rewardTransformPoint;
        [SerializeField] private RewardType rewardType;
        public Transform RewardTransformPoint => rewardTransformPoint;
        public RewardType RewardType => rewardType;
    }
}