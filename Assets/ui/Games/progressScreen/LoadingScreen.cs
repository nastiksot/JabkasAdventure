using System;
using System.Collections;
using DI;
using UI.Base;
using UI.Camera;
using UnityEngine;

namespace UI.Games.progressScreen
{
    public class LoadingScreen : BaseMono
    {
        [Header("Camera Settings")] 
        [SerializeField] private Canvas canvas;

        [Header("Canvas Dots")]
        [SerializeField] private CanvasGroup[] canvasDots;
        
        private Coroutine dotCoroutine;

        private void Awake()
        {
            HideDotsOnAwake();
        }

        public void Start()
        {
            GetCameraSystem();
            StartCoroutine(startWithDelay(3f,()=>
            {
                StopAllCoroutines();
                OpenMainGame();
            }));
            dotCoroutine = StartCoroutine(DotsAnimation());
        }

        /// <summary>
        /// Animation of appearing dots by script
        /// </summary>
        /// <returns></returns>
        private IEnumerator DotsAnimation()
        {
            while (true)
            { 
                foreach (var canvasGroup in canvasDots)
                {
                    var dot = canvasGroup;
                    CanvasTool.State(ref dot, true); 
                    yield return new WaitForSeconds(0.4f);
                }
                yield return new WaitForSeconds(0.2f);
                foreach (var canvasGroup in canvasDots)
                {
                    var dot = canvasGroup;
                    CanvasTool.State(ref dot, false);
                } 
                yield return new WaitForSeconds(0.2f);
            } 
        }

        /// <summary>
        /// Hide dots on awake
        /// </summary>
        private void HideDotsOnAwake()
        {
            foreach (var canvasGroup in canvasDots)
            {
                var dot = canvasGroup;
                CanvasTool.State(ref dot, false);  
            }
        }

        /// <summary>
        /// Get camera system
        /// </summary>
        private void GetCameraSystem()
        {
            MainDependency.GetInstance().GetReferenceManager().GetCameraSystem(
                camera => { canvas.worldCamera = camera.Camera; },
                error => { ToastUtility.ShowToast(error.errorMessage); });
        }

        /// <summary>
        /// Open mario level
        /// </summary>
        private void OpenMainGame()
        {
            MainDependency.GetInstance().GetUIManager().GetNavigator().InitMarioLevel();
        }
    }
}