using Standard_Assets.CrossPlatformInput.Scripts;
using UnityEngine;

namespace UI.Navigation
{
    public class NavigationMenu : MonoBehaviour
    {
        [SerializeField] private CanvasGroup navigationCanvas;

        public CanvasGroup NavigationCanvas => navigationCanvas;
    }
}