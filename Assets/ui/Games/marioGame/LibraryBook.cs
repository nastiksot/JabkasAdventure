using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class LibraryBook : MonoBehaviour
{
    private bool isContainSheet = true;
    [SerializeField] private Sprite[] shelfSprite;

    [SerializeField] private GameObject CVSheet;
    //public AudioSource hitBlock;

    private bool isShelfClosed = true;


    void Start()
    {
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        //compare collision BonusBlock and Player
        if (col.collider.bounds.max.y < transform.position.y &&
            col.collider.bounds.min.x < transform.position.x + 0.3f &&
            col.collider.bounds.min.x < transform.position.x - 0.3f &&
            col.gameObject.GetComponent<PlayerBehaviourImpl>())
        {
            //check of condition BonusBlock(empty or full) 
            if (isContainSheet)
            {
                //hitBlock.Play();
                gameObject.GetComponent<SpriteRenderer>().sprite = shelfSprite[0]; 
                isContainSheet = false;
            }

            if (!isContainSheet)
            {
                StartCoroutine(WaitForHalfASecond());
                GetComponent<Animator>().SetBool("isEmpty", true);
                gameObject.GetComponent<SpriteRenderer>().sprite = shelfSprite[1];
            }
        }
    }

    IEnumerator WaitForHalfASecond()
    {
        yield return new WaitForSeconds(0.17f);
        if (isShelfClosed)
        {
            //drop list just once
            Instantiate(CVSheet, transform.position + Vector3.up, Quaternion.identity);
            isShelfClosed = false;
        }
    }
}