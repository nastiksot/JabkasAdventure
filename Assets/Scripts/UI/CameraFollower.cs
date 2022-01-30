using UI.Player.Interfaces;
using UnityEngine;
using Zenject;

namespace UI
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private float lookAheadFactor = 3;
        [SerializeField] private float lookAheadReturnSpeed = 0.5f;
        [SerializeField] private float lookAheadMoveThreshold = 0.1f;

        private float offsetZ;
        private float offsetY;
        private Vector3 target;
        private Vector3 lastTargetPosition;
        private Vector3 currentVelocity;
        private Vector3 lookAheadPos;
        private Vector3 playerPosition;

        private IPlayerBehaviour playerBehaviour;

        [Inject]
        public void Construct(IPlayerBehaviour playerBehaviour)
        {
            this.playerBehaviour = playerBehaviour;
        }

        private void Start()
        {
            playerPosition = playerBehaviour.GetPlayerPosition();
            var offsetPlayerPosition = new Vector3(playerPosition.x, playerPosition.y + 0.5f, playerPosition.z);
            target = offsetPlayerPosition;
            lastTargetPosition = playerBehaviour.GetPlayerPosition();
            offsetZ = (transform.position - target).z;
            offsetY = (transform.position - target).y;
            transform.parent = null;
        }


        private void Update()
        {
            playerPosition = playerBehaviour.GetPlayerPosition();
            var offsetPlayerPosition = new Vector3(playerPosition.x, playerPosition.y + 0.5f, playerPosition.z);
            target = offsetPlayerPosition;

            var xMoveDelta = (target - lastTargetPosition).x;

            var updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            lookAheadPos = updateLookAheadTarget ? lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta) : Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);


            var aheadTargetPos = target + lookAheadPos + Vector3.forward * offsetZ;
            var newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, 0);

            transform.position = newPos;
            lastTargetPosition = target;
        }
    }
}