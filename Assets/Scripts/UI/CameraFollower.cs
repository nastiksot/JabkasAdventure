using UI.Player.Interfaces;
using UnityEngine;
using Utility;
using Zenject;

namespace UI
{
    public class CameraFollower : ObjectFollower
    {
        private IPlayerBehaviour playerBehaviour;
        private Vector3 offsetY = new Vector3(0f, 1.1f, 0f);
        private float leftBorderX = -11.5f;

        [Inject]
        private void Construct(IPlayerBehaviour playerBehaviour)
        {
            this.playerBehaviour = playerBehaviour;
        }

        private void Start()
        {
            objToFollow = playerBehaviour.GetPlayerTransform();
            SetOffsetPosition(offsetY);
        }
        
        
        
    }
}