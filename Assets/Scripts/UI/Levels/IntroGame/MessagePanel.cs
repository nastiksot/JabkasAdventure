using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI.Levels.IntroGame
{
    public class MessagePanel : MonoBehaviour
    {
        [SerializeField] private CanvasGroup panelCanvasGroup;
        [SerializeField] private Button panelButton;
        [SerializeField] private Button submitButton;
        
        private bool isOpen = false;

        private void Awake()
        {
            panelCanvasGroup.State(false);
            panelButton.onClick.AddListener(OpenPanel);
            submitButton.onClick.AddListener(ClosePanel);
        }

        /// <summary>
        /// Close message panel
        /// </summary>
        private void ClosePanel()
        {
            panelCanvasGroup.State(isOpen);
            Time.timeScale = 1f;
            isOpen = !isOpen;
        }

        /// <summary>
        /// Open message panel
        /// </summary>
        private void OpenPanel()
        {
            panelCanvasGroup.State(isOpen);
            Time.timeScale = 0f;
            isOpen = !isOpen;
        }
    }
}