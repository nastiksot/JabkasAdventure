using System;
using UI.Base;
using UI.Games;
using UI.movement;
using UnityEngine;

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