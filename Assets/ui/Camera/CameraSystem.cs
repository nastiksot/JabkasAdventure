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
            
            GetPlayer();
            
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

        /// <summary>
        /// Setup camera settings from level Scriptable Object
        /// </summary>
        /// <param name="cameraData"></param>
        private void SetSettingsOnLevelChanged(CameraData cameraData)
        {
            if (cameraData == null)
            {
                SetCameraParams(defaultCameraData);
                return;
            }

            GetPlayer();
            SetCameraData(cameraData);
            SetCameraSize(cameraData);
            SetCameraParams(cameraData);
        } 

        /// <summary>
        /// Set camera data from Scriptable Objects
        /// </summary>
        /// <param name="cameraData"></param>
        private void SetCameraData(CameraData cameraData)
        {
            this.cameraData = cameraData;
        }
        
        /// <summary>
        /// Set camera size
        /// </summary>
        /// <param name="data"></param>
        private void SetCameraSize(CameraData data)
        {
            camera.orthographicSize = data.cameraSize;
        }

        /// <summary>
        /// Set camera params
        /// </summary>
        /// <param name="newCameraData"></param>
        private void SetCameraParams(CameraData newCameraData)
        {
            cameraData.XValues.MIN = newCameraData.XValues.MIN;
            cameraData.XValues.MAX = newCameraData.XValues.MAX;
            cameraData.YValues.MIN = newCameraData.YValues.MIN;
            cameraData.YValues.MAX = newCameraData.YValues.MAX;
        }
        
        /// <summary>
        /// Get player script
        /// </summary>
        private void GetPlayer()
        {
            MainDependency.GetInstance().GetReferenceManager().GetPlayer(player => { playerObject = player; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }
    }
}