using Models.Enum;

namespace Services.Interfaces
{
    public interface IRewardService
    {
        public int GetBonusReward(RewardType rewardType);
    }
}