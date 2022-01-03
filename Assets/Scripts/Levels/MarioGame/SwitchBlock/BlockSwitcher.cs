using Levels.MarioGame.SwitchBlock.Interface;
using Models;
using UnityEngine;
using Zenject;

namespace Levels.MarioGame.SwitchBlock
{
    public class BlockSwitcher : MonoBehaviour
    {
        [SerializeField] Sprite[] blockSprite;
        [SerializeField] private SpriteRenderer spriteRenderer;
     
        private bool isOnSprite;
        private bool setOnSprite = false;
        private bool setOffSprite = false;

        private ISwitcher switcher;

        [Inject]
        public void Construct(ISwitcher switcher)
        {
            this.switcher = switcher;
        }

        private void Start()
        {
            switcher.OnBlockSwitched += ChangeBlockState;
        }

        private void ChangeBlockState(bool isOn)
        {
            isOnSprite = isOn;
            
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
                switcher.FlipSwitch();
            }
        }
    }
}