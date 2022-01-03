using UnityEngine;
using Utility;
using Zenject;

namespace UI
{
    public class ButtonUIInput : MonoBehaviour
    {
        [SerializeField] private CanvasGroup navigationCanvas;
 
        private PauseMenu pauseMenu;

        [Inject]
        public void Construct(PauseMenu pauseMenu)
        {
            this.pauseMenu = pauseMenu;
        }

        private void Awake()
        {
            pauseMenu.OnPauseButtonPressed += () => SetButtonInputVisibility(false);
            pauseMenu.OnContinueButtonPressed += () => SetButtonInputVisibility(true);
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