using System.Collections;
using Models.ConstantValues;
using UnityEngine;
using Utility;

namespace UI.Levels.IntroGame
{
    public class NewsStand : MonoBehaviour
    {
        [SerializeField] private CanvasGroup bubbleMessageCanvasGroup;
        [SerializeField] private AudioSource audioSource;

        private void Awake()
        {
            bubbleMessageCanvasGroup.State(false);
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return;
            audioSource.Play();
            bubbleMessageCanvasGroup.State(true);
            StartCoroutine(HideBubble());
        }

        /// <summary>
        /// Close question bubble message
        /// </summary>
        /// <returns></returns>
        private IEnumerator HideBubble()
        {
            yield return new WaitForSeconds(3);
            bubbleMessageCanvasGroup.State( false);
            yield return null;
        }
    }
}