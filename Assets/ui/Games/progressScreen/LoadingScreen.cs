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


        public void Start()
        {
            GetCameraSystem();
            StartCoroutine(startWithDelay(3f, OpenMainGame));
        }

        private void GetCameraSystem()
        {
            MainDependency.GetInstance().GetGameManager().GetCameraSystem(camera => { canvas.worldCamera = camera.Camera; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        private void OpenMainGame()
        { 
            MainDependency.GetInstance().GetUIManager().GetNavigator().InitMainLevel();
        }
    }
}