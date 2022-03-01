using UI.Player.Interfaces;
using UnityEngine;
using Utility;
using Zenject;

namespace UI
{
    public class CameraFollower : ObjectFollower
    {
        private IPlayerBehaviour playerBehaviour;
        private Vector3 OffsetY = new Vector3(0f, 0.7f, 0f);

        [Inject]
        private void Construct(IPlayerBehaviour playerBehaviour)
        {
            this.playerBehaviour = playerBehaviour;
        }

        private void Start()
        {
            objToFollow = playerBehaviour.GetPlayerTransform();
            SetOffsetPosition(OffsetY);
        }
    }
}