using System;
using DI;
using UI.Base;
using UI.Player;
using UI.ScriptableObjects;
using UnityEngine;

namespace UI.Camera
{
    public class CameraSystem : BaseMono
    {
        [SerializeField] private PlayerBehaviour playerObject;
        [SerializeField] private UnityEngine.Camera camera;


        [SerializeField] private CameraData cameraData;
        [SerializeField] private CameraData defaultCameraData;

        private Action<CameraData> onLevelSwitched;

        public Action<CameraData> OnLevelSwitched => onLevelSwitched;
        public UnityEngine.Camera Camera => camera;

        private void Start()
        {
            onLevelSwitched += SetSettingsOnLevelChanged;
            MainDependency.GetInstance().GetGameManager().GetPlayer(player => { playerObject = player; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
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

        private void SetSettingsOnLevelChanged(CameraData cameraData)
        {
            if (cameraData == null)
            {
                SetCameraParams(defaultCameraData);
                return;
            }

            SetPlayer();
            SetCameraData(cameraData);
            SetCameraSize(cameraData);
            SetCameraParams(cameraData);
        }

        private void SetPlayer()
        {
            if (playerObject != null) return;
            MainDependency.GetInstance().GetGameManager().GetPlayer(player => { playerObject = player; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
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