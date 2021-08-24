using DI.Services.Constants;
using UI.Base;
using UnityEngine;

namespace UI.Games.MarioGame.Switcher
{
    public class BlockSwitcher : BaseMono
    {
        [SerializeField] Sprite[] blockSprite;
        [SerializeField] private SpriteRenderer spriteRenderer;
    
        private SwitchController switchController;
        private bool isOnSprite;
        private bool setOnSprite = false;
        private bool setOffSprite = false;

        private void Start()
        {
            switchController = FindObjectOfType<SwitchController>();
        }

        void Update()
        {
            isOnSprite = SwitchController.instance.IsOn;

            if (!setOnSprite && isOnSprite)
            {
                spriteRenderer.sprite = blockSprite[1];
                setOnSprite = true;
                setOffSprite = false;
            }

            if (setOffSprite || isOnSprite) return;
            spriteRenderer.sprite = blockSprite[0];
            setOffSprite = true;
            setOnSprite = false;
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.bounds.max.y < transform.position.y &&
                col.collider.bounds.min.x < transform.position.x + 0.3f &&
                col.collider.bounds.min.x < transform.position.x - 0.3f &&
                col.gameObject.CompareTag(Tags.PLAYER_TAG))
            {
                switchController.FlipSwitch();
            }
        }
    }
}