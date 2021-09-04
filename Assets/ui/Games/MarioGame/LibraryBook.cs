using System.Collections;
using DI.Services.Constants;
using UI.Base;
using UnityEngine;

namespace UI.Games.MarioGame
{
    public class LibraryBook : BaseMono
    {
        [SerializeField] private SpriteRenderer blockSprite;  
        [SerializeField] private Sprite emptyShelfSprite;
        [Space (6f), Header("Prefab")][SerializeField] private GameObject CVSheet;

        //private AudioSource hitBlock;
        private bool isContainSheet = true;
        private bool isShelfClosed = true;
 
        private void OnCollisionEnter2D(Collision2D col)
        { 
            if (col.collider.bounds.max.y < transform.position.y &&
                col.collider.bounds.min.x < transform.position.x + 0.3f &&
                col.collider.bounds.min.x < transform.position.x - 0.3f &&
                col.gameObject.CompareTag(Tags.PLAYER_TAG))
            {
                if (isContainSheet)
                {
                    //TODO: init sound hit block; 
                    isContainSheet = false;
                }

                if (isContainSheet) return;
                StartCoroutine(InitializeBonusSheet());  
                blockSprite.sprite = emptyShelfSprite;
            }
        }

        private IEnumerator InitializeBonusSheet()
        {
            yield return new WaitForSeconds(0.17f);
            if (!isShelfClosed) yield break;
            Instantiate(CVSheet, transform.position + Vector3.up*2, Quaternion.identity); 
            isShelfClosed = false;
        }
 
    }
}