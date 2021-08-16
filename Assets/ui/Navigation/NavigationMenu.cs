using Standard_Assets.CrossPlatformInput.Scripts;
using UnityEngine;

namespace UI.Navigation
{
    public class NavigationMenu : MonoBehaviour
    {
        [SerializeField] private AxisTouchButton leftArrow;
        [SerializeField] private AxisTouchButton rightArrow;
        [SerializeField] private ButtonHandler jumpButton;
    }
}