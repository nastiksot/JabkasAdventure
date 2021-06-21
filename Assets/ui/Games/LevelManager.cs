using System;
using UnityEngine;

    public class LevelManager : BaseMono
    {
        [SerializeField] private CameraSystem cameraSystem;
        [SerializeField] private Vector2 minCoordinates;
        [SerializeField] private Vector2 maxCoordinates;
        [SerializeField] private float cameraSize;

        private void Start()
        {
            cameraSystem = FindObjectOfType<CameraSystem>();
            cameraSystem.SetCameraParams(minCoordinates, maxCoordinates);
            cameraSystem.SetPlayer();
            cameraSystem.SetCameraSize(cameraSize);
        }
    } 