using System;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Games.IntroGame
{
    public class MessagePanel  : MonoBehaviour
    {
        [SerializeField] private CanvasGroup panelCanvasGroup;
        [SerializeField] private Button panelButton;
        [SerializeField] private Button submitButton;
        private bool isOpen = false;

        private void Awake()
        {
            panelButton.onClick.AddListener(OpenPanel);
            submitButton.onClick.AddListener(ClosePanel);
        }

        /// <summary>
        /// Close message panel
        /// </summary>
        public void ClosePanel()
        {
            CanvasTool.State(ref panelCanvasGroup, isOpen);
            Time.timeScale = 1f;
            isOpen = !isOpen;
        }

        /// <summary>
        /// Open message panel
        /// </summary>
        public void OpenPanel()
        {
            CanvasTool.State(ref panelCanvasGroup, isOpen);
            Time.timeScale = 0f;
            isOpen = !isOpen;
        }
    }
}