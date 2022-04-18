using UI.Player.Interfaces;
using UnityEngine;
using Zenject;

namespace UI
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Camera levelCamera;
        [SerializeField] private Transform followObject;
        [SerializeField] private float minY;
        [SerializeField] private float minX; 

        private float cameraSpeed = 0.4f;
        private IPlayerBehaviour playerBehaviour;

        [Inject]
        private void Construct(IPlayerBehaviour playerBehaviour)
        {
            this.playerBehaviour = playerBehaviour;
        }

        private void Start()
        {
            followObject = playerBehaviour.PlayerTransform;
        }

        public void Update()
        {
            if (followObject == null) return;
            Follow();
        }

        private void Follow()
        {
            var cameraPosition = transform.position;
            var targetPosition = followObject.position;
            if (targetPosition.x - levelCamera.orthographicSize * levelCamera.aspect > minX)
            {
                cameraPosition.x = targetPosition.x;
            }
            else
            {
                cameraPosition.x = minX + levelCamera.orthographicSize * levelCamera.aspect;
            }

            if (targetPosition.y - levelCamera.orthographicSize > minY)
            {
                cameraPosition.y = targetPosition.y;
            }
            else
            {
                cameraPosition.y = minY + levelCamera.orthographicSize;
            }

            transform.position = Vector3.MoveTowards(transform.position, cameraPosition, cameraSpeed);
        }
    }
}