using DI;
using UI.Base;
using UI.Camera;
using UnityEngine;

namespace UI.Games.progressScreen
{
    public class LoadingScreen : BaseMono
    {
        [Header("Camera Settings")] [SerializeField]
        private Canvas canvas;
 

        void Awake()
        {
            InitializeCameraSystem();

            StartCoroutine(startWithDelay(3f, OpenMainGame));
        }

        private void InitializeCameraSystem()
        {
            MainDependency.GetInstance().GetGameManager().GetCameraSystem(camera => { canvas.worldCamera = camera.Camera; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        void OpenMainGame()
        {
            MainDependency.GetInstance().GetUIManager().GetNavigator().InitMainLevel();
        }
    }
}