using UI.Base;
using UnityEngine;

namespace UI.Games.MarioGame.Switcher
{
    public class OrangeBlock : BaseMono
    {
        [Header("Sprites")] [SerializeField] private Sprite[] orangeSprites;
        
        [Space(6f)] [SerializeField] private BoxCollider2D collider2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private bool isActive;
        private Color semiVisible = new Color(1, 1, 1, 0.5f);
        private bool setOn;
        private bool setOff; 
    
        void Update()
        {
            isActive = SwitchController.instance.IsOn;

            if (!setOn && !isActive)
            {
                collider2D.enabled = true;
                spriteRenderer.sprite = orangeSprites[0];
                spriteRenderer.color = Color.white;
                setOn = true;
                setOff = false;
            }

            if (setOff || !isActive) return;
            collider2D.enabled = false;
            spriteRenderer.sprite = orangeSprites[1];
            spriteRenderer.color = semiVisible;
            setOff = true;
            setOn = false;
        }
    }
}