using DI;
using UI.Base;
using UI.Camera;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Games.Menus
{
    public class MainMenu : BaseMono
    {
        [Header("Buttons")] 
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        
        [Header("Camera Settings")] 
        [SerializeField] private Canvas canvas;

        private CameraSystem cameraSystem;
        private void Start()
        {
            MainDependency.GetInstance().GetGameManager().GetCameraSystem(camera =>
                {
                    cameraSystem = camera;
                    canvas.worldCamera = camera.Camera; 
                },
                error => { ToastUtility.ShowToast(error.errorMessage); });
            InitGame();
        }

        private void InitGame()
        {
            playButton.onClick.AddListener(() =>
            {
                MainDependency.GetInstance().GetUIManager().GetNavigator().InitIntroLevel();
            });
#if PLATFORM_ANDROID
            settingsButton.onClick.AddListener(Application.Quit);
#endif
        }
    }
} 