using UI.Base;
using UnityEngine;

public class OrangeBlock : BaseMono
{
    [SerializeField] private Sprite[] onSprite;
    private bool isActive;
    private Color semiVisible = new Color(1, 1, 1, 0.5f);
    private bool setOn;
    private bool setOff; 
    
    void Update()
    {
        isActive = SwitchController.instance.isOn;

        if (!setOn && !isActive)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = onSprite[0];
            gameObject.GetComponent<SpriteRenderer>().color = semiVisible;
            setOn = true;
            setOff = false;
        }

        if (!setOff && isActive)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = onSprite[1];
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            setOff = true;
            setOn = false;
        }
    }
}