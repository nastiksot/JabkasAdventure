using System.Collections;
using System.Collections.Generic;
using UnityEngine;    

public class CameraSystem : BaseMono
{
    [SerializeField]private GameObject playerObject;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
 
    // Update is called once per frame
    void LateUpdate()
    {
        var playerPosition = playerObject.transform.position;
        float x = Mathf.Clamp(playerPosition.x, xMin, xMax);
        float y = Mathf.Clamp(playerPosition.y, yMin, yMax);
        var go = gameObject;
        go.transform.position = new Vector3(x, y, go.transform.position.z);
    }
}