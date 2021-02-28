using UnityEngine;

public class InitCanvas : BaseMono
{
    void Start()
    { 
        GetComponent<Canvas>(). renderMode = RenderMode.ScreenSpaceCamera;
        GetComponent<Canvas>(). worldCamera =  Camera.main; 
    }
}