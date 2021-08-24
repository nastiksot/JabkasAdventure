using DI;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Games.Menus
{
    public class GameOverMenu : BaseMono
    {
        [Header("Buttons")]
        [SerializeField] private Button retryButton;
        [SerializeField] private Button exitButton;
        
        [Space(6f)]
        [SerializeField] private CanvasGroup background;

        private void Start()
        {
            retryButton.onClick.AddListener(() =>
            {
               MainDependency.GetInstance().GetUIManager().GetNavigator().StartLoadingScreen();
            }); 
            exitButton.onClick.AddListener(() =>
            {
                MainDependency.GetInstance().GetUIManager().GetNavigator().InitMainMenu();
            }); 
            SetCanvasVisibility(false);
        }
        private void SetCanvasVisibility(bool state)
        {
            CanvasTool.State(ref background, state);
        }
    }
}