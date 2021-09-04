using DI.Services.Constants;
using UI.Base;
using UnityEngine;

namespace UI.Games.MarioGame.Switcher
{
    public class BlueBlock : BaseMono
    {
        [Header("Sprites")] [SerializeField] private Sprite[] blueSprites;

        [Space(6f)] [SerializeField] private BoxCollider2D collider2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private bool isActive;
        private Color semiVisible = new Color(1, 1, 1, 0.5f);
        private bool setOn;
        private bool setOff;


        private void Update()
        {
            isActive = SwitchController.instance.IsOn;

            if (!setOn && isActive)
            {
                collider2D.isTrigger = false;
                spriteRenderer.sprite = blueSprites[1];
                gameObject.layer = Layers.GROUND_LAYER;
                spriteRenderer.color = Color.white;
                setOn = true;
                setOff = false;
            }


            if (setOff || isActive) return;
            collider2D.isTrigger = true;
            spriteRenderer.sprite = blueSprites[0];
            gameObject.layer = Layers.SWITCHER_LAYER;
            spriteRenderer.color = Color.white;
            setOff = true;
            setOn = false;
        }
    }
}