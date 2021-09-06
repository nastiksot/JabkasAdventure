using System;
using DI;
using UI.Base;
using UI.Camera;
using UI.DataSaver;
using UI.Player;
using UI.ScriptableObjects;
using UnityEngine;

namespace UI.Games
{
    public class LevelManager : BaseMono
    {
        [Header("Camera")] [SerializeField] private CameraSystem cameraSystem;
        [SerializeField] private CameraData cameraData;

        [Space(6f)] [SerializeField] private Transform spawnPosition;
        [Space(6f)] [SerializeField] private PlayerBehaviour playerBehaviour;
        [Space(6f)] [SerializeField] private BaseMono gameLevelManager;
  
        private void Start()
        {
            GetCameraSystem();
            GetPlayer();
        }

        /// <summary>
        /// Get Camera System
        /// </summary>
        private void GetCameraSystem()
        {
            MainDependency.GetInstance().GetReferenceManager().GetCameraSystem(camera =>
            {
                cameraSystem = camera;
                cameraSystem.OnLevelSwitched?.Invoke(cameraData);
            }, error => { ToastUtility.ShowToast(error.errorMessage); });
        }
 
        /// <summary>
        /// Get Player script
        /// </summary>
        private void GetPlayer()
        {
            MainDependency.GetInstance().GetReferenceManager().GetPlayer(player => { playerBehaviour = player; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
            // playerBehaviour.transform.position = spawnPosition.position;
        }
    }
}