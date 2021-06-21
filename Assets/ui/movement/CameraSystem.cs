using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraSystem : BaseMono
{
    [SerializeField] private PlayerBehaviour playerObject;
    [SerializeField] private Camera camera;
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;
     
    private void Start()
    {
        playerObject = FindObjectOfType<PlayerBehaviour>();
        if (playerObject == null)
        {
            SetCameraParams(Vector2.zero, Vector2.zero);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    
    // Update is called once per frame
    private void LateUpdate()
    {
        if (playerObject == null) return;
        var playerPosition = playerObject.transform.position;
        var x = Mathf.Clamp(playerPosition.x, xMin, xMax);
        var y = Mathf.Clamp(playerPosition.y, yMin, yMax);
        var go = gameObject;
        go.transform.position = new Vector3(x, y, go.transform.position.z);
    }

    public void SetPlayer()
    {
        playerObject = FindObjectOfType<PlayerBehaviour>();
    }

    public void SetCameraSize(float cameraSize)
    {
        camera.orthographicSize = cameraSize;
    }

    public void SetCameraParams(Vector2 minCoordinates, Vector2 maxCoordinates)
    {
        this.xMin = minCoordinates.x;
        this.xMax = maxCoordinates.x;
        this.yMin = minCoordinates.y;
        this.yMax = maxCoordinates.y;
    }
}