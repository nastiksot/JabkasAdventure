using System.Collections;
using DI.Services.Constants;
using UI.Base;
using UnityEngine;

namespace UI.Games.IntroGame
{
    public class NewsStand : BaseMono
    {
        [SerializeField] private GameObject bubbleMessage;
        [SerializeField] private AudioSource audioSource; 

        private void Awake()
        {
            bubbleMessage.SetActive(false);
        }
 

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            audioSource.Play();
            bubbleMessage.SetActive(true);
            StartCoroutine(HideBubble());
        }
 

        public IEnumerator HideBubble()
        {
            yield return new WaitForSeconds(3);
            bubbleMessage.SetActive(false);
        }
    }
}