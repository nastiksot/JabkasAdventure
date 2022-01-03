using UI.Base;
using UnityEngine;

namespace Navigation
{
    public class ButtonUIInput : MonoBehaviour
    {
        [SerializeField] private CanvasGroup navigationCanvas;

        public CanvasGroup NavigationCanvas => navigationCanvas;
        
        /// <summary>
        /// Set navigation menu visibility
        /// </summary>
        /// <param name="state"></param>
        public void SetNavigationMenuVisibility(bool state)
        { 
            CanvasTool.State(ref navigationCanvas, state);
        }
    }
}