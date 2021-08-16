using System;
using UI.Base;
using UI.Player;
using UI.ScriptableObjects;
using UnityEngine;

namespace UI.CameraSystem
{
    public class CameraSystem : BaseMono
    {
        [SerializeField] private PlayerBehaviour playerObject;
        [SerializeField] private Camera camera;
        [SerializeField] private CameraData cameraData;
        [SerializeField] private CameraData defaultCameraData;

        private event Action<CameraData> onLevelChanged;

        public Action<CameraData> OnLevelChanged => onLevelChanged;

        private void Start()
        {
            onLevelChanged += ONLevelChanged;

            playerObject = FindObjectOfType<PlayerBehaviour>();
            if (playerObject != null) return;
            cameraData = defaultCameraData;
            SetCameraParams(defaultCameraData);
        }

        private void LateUpdate()
        {
            if (playerObject == null) return;
            var playerPosition = playerObject.transform.position;
            var x = Mathf.Clamp(playerPosition.x, cameraData.XValues.MIN, cameraData.XValues.MAX);
            var y = Mathf.Clamp(playerPosition.y, cameraData.YValues.MIN, cameraData.YValues.MAX);
            var go = gameObject;
            go.transform.position = new Vector3(x, y, go.transform.position.z);
        }

        private void SetCameraData(CameraData cameraData)
        {
            this.cameraData = cameraData;
        }

        private void ONLevelChanged(CameraData cameraData)
        {
            SetPlayer();
            SetCameraData(cameraData);
            SetCameraSize(cameraData);
            SetCameraParams(cameraData);
        }

        private void SetPlayer()
        {
            if (playerObject != null) return;
            playerObject = FindObjectOfType<PlayerBehaviour>();
        }

        private void SetCameraSize(CameraData data)
        {
            camera.orthographicSize = data.cameraSize;
        }

        private void SetCameraParams(CameraData newCameraData)
        {
            cameraData.XValues.MIN = newCameraData.XValues.MIN;
            cameraData.XValues.MAX = newCameraData.XValues.MAX;
            cameraData.YValues.MIN = newCameraData.YValues.MIN;
            cameraData.YValues.MAX = newCameraData.YValues.MAX;
        }
    }
}