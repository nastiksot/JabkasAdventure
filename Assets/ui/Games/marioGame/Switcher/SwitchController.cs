using UnityEngine;

public class SwitchController : BaseMono
{
    public static SwitchController instance = null;
    public bool isOn ;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void FlipSwitch()
    {
        isOn = !isOn;
    }
}