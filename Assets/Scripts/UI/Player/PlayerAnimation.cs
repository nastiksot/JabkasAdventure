using Models.ConstantValues;
using UnityEngine;

namespace UI.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;

        public void SetJumpAnimation()
        {
            playerAnimator.ResetTrigger(AnimationProperties.PLAYER_RUN);
            playerAnimator.SetTrigger(AnimationProperties.PLAYER_JUMP);
        }
        public void SetRunAnimation()
        {
            playerAnimator.ResetTrigger(AnimationProperties.PLAYER_JUMP);
            playerAnimator.SetTrigger(AnimationProperties.PLAYER_RUN);
        }
        public void SetIdleAnimation()
        {
            playerAnimator.ResetTrigger(AnimationProperties.PLAYER_JUMP);
            playerAnimator.ResetTrigger(AnimationProperties.PLAYER_RUN);
        }
        

    }
}