using Services;
using Services.Interfaces;
using UnityEngine;
using Utility;
using Zenject;

namespace UI
{
    public class ButtonUIInput : MonoBehaviour
    {
        [SerializeField] private CanvasGroup navigationCanvas;
 
        private IPauseMenuService pauseMenuService;

        [Inject]
        private void Construct(IPauseMenuService pauseMenuService)
        {
            this.pauseMenuService = pauseMenuService;
        }

        private void Awake()
        {
            pauseMenuService.OnPauseButtonPressed += () => SetButtonInputVisibility(false);
            pauseMenuService.OnContinueButtonPressed += () => SetButtonInputVisibility(true);
        }

        /// <summary>
        /// Set navigation menu visibility
        /// </summary>
        /// <param name="state"></param>
        private void SetButtonInputVisibility(bool state)
        { 
            navigationCanvas.State(state); 
        }
    }
}