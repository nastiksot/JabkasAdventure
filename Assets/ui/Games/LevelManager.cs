using UI.Base;
using UI.movement;
using UnityEngine;

namespace UI.Games
{
    public class LevelManager : BaseMono
    {
        [SerializeField] private CameraSystem cameraSystem;
        [SerializeField] private CameraData cameraData; 

        private void Start()
        {
            cameraSystem = FindObjectOfType<CameraSystem>();
            cameraSystem.OnLevelChanged?.Invoke(cameraData);
        }
    }
} 