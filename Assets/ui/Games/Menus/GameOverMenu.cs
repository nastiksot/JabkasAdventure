using DI;
using TMPro;
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
        
        [Header("Text")]
        [SerializeField] private TMP_Text scoreText;

        [Space(6f)]
        [SerializeField] private CanvasGroup background;


        public CanvasGroup Background => background;
        public string ScoreText
        {
            get => scoreText.text;
            set => scoreText.text = value;
        }

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