using System;
using UI.Timer;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Games.Menus
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private TimerManager timerManager;
        [SerializeField] private GameObject background;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button exitButton;

        private void Awake()
        {
            timerManager = FindObjectOfType<TimerManager>();
            if (timerManager == null) return;
            
            continueButton.onClick.AddListener(() =>
            {
                background.SetActive(false);
                timerManager.Unpause();
            });
#if PLATFORM_ANDROID
            exitButton.onClick.AddListener(Application.Quit);
#endif
            background.SetActive(false);
        }
    }
}