using System;
using UnityEngine;


public class BlockSwitcher : MonoBehaviour
{
    [SerializeField] Sprite[] blockSprite;
    private SwitchController switchController;
    private bool isOnSprite;
    private bool setOnSprite = false;
    private bool setOffSprite = false;

    private void Start()
    {
        switchController = Camera.main.GetComponent<SwitchController>();
    }

    void Update()
    {
        isOnSprite = SwitchController.instance.isOn;

        if (!setOnSprite && isOnSprite)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = blockSprite[1];
            setOnSprite = true;
            setOffSprite = false;
        }

        if (!setOffSprite && !isOnSprite)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = blockSprite[0];
            setOffSprite = true;
            setOnSprite = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.bounds.max.y < transform.position.y &&
            col.collider.bounds.min.x < transform.position.x + 0.3f &&
            col.collider.bounds.min.x < transform.position.x - 0.3f &&
            col.gameObject.GetComponent<PlayerBehaviourImpl>())
        {
            switchController.FlipSwitch();
        }
    }
}