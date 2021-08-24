using System.Collections;
using DI.Services.Constants;
using UI.Base;
using UnityEngine;

namespace UI.Games.IntroGame
{
    public class NewsStand : BaseMono
    {
        [SerializeField] private CanvasGroup bubbleMessageCanvasGroup;
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            CanvasTool.State(ref bubbleMessageCanvasGroup, false);
        }


        public void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            audioSource.Play();
            CanvasTool.State(ref bubbleMessageCanvasGroup,
                true);
            StartCoroutine(HideBubble());
        }


        private IEnumerator HideBubble()
        {
            yield return new WaitForSeconds(3);
            CanvasTool.State(ref bubbleMessageCanvasGroup, false);
        }
    }
}