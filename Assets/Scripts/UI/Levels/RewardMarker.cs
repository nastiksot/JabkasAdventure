using System;
using Models.Enum;
using Services.Interfaces;
using UnityEngine;
using Zenject;

namespace UI.Levels
{
    public class RewardMarker : MonoBehaviour
    {
        [SerializeField] private Transform rewardTransformPoint;
        [SerializeField] private RewardType rewardType;
        public Transform RewardTransformPoint => rewardTransformPoint;
        public RewardType RewardType => rewardType;

        private IStatisticService statisticService;
        
        [Inject]
        private void Construct(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }

        private void Start()
        {
            statisticService.AddEnemy();
        }
    }
}