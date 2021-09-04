using UI.Base;
using UnityEngine;

namespace UI.Games.IntroGame
{
    public class MessagePanel : BaseMono
    {
        [SerializeField] private CanvasGroup panelCanvasGroup;
        [SerializeField] private bool isOpen = false;

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