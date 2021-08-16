using System;
using UI.Base;
using UI.DataSaver;
using UI.Player;
using UI.ScriptableObjects;
using UnityEngine;

namespace UI.Games
{
    public class LevelManager : BaseMono
    {
        [Header("Camera")][SerializeField] private CameraSystem.CameraSystem cameraSystem;
        [SerializeField] private CameraData cameraData;
        
        [Space(6f)][SerializeField] private Transform spawnPosition;
        
        [Space(6f)][SerializeField] private PlayerBehaviour playerBehaviour;
        
        private void Awake()
        {
            cameraSystem = FindObjectOfType<CameraSystem.CameraSystem>();
            cameraSystem.OnLevelChanged?.Invoke(cameraData);
        }

        private void Start()
        {
            InitPlayer();
        }

        private void InitPlayer()
        {
            playerBehaviour = FindObjectOfType<PlayerBehaviour>();
           // playerBehaviour.transform.position = spawnPosition.position;
        }
    }
} 