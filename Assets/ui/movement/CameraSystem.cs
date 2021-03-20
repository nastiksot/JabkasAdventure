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
        float x = Mathf.Clamp(playerObject.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(playerObject.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}