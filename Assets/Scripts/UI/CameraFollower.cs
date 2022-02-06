using System;
using UI.Player.Interfaces;
using Utility;
using Zenject;

namespace UI
{
    public class CameraFollower : ObjectFollower
    {
        private IPlayerBehaviour playerBehaviour;
        
        [Inject]
        private void Construct(IPlayerBehaviour playerBehaviour)
        {
            this.playerBehaviour = playerBehaviour;
        }

        private void Start()
        {
            objToFollow = playerBehaviour.GetPlayerTransform();
        }
    }
}