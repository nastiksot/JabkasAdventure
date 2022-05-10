using System;
using System.Threading.Tasks;
using Models.ConstantValues;
using Models.Enum;
using Services.Interfaces;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private SceneType nextSceneType;

        private int sceneLoadDelay = 2000;
        private Action onTeleportCollision;

        private ISceneService sceneService;
        private ButtonUIInput buttonUIInput;
        private IPauseMenuService pauseMenuService;

        public event Action OnTeleportCollision
        {
            add => onTeleportCollision += value;
            remove => onTeleportCollision -= value;
        }

        [Inject]
        private void Construct(ISceneService sceneService, ButtonUIInput buttonUIInput, IPauseMenuService pauseMenuService)
        {
            this.sceneService = sceneService;
            this.buttonUIInput = buttonUIInput;
            this.pauseMenuService = pauseMenuService;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return; 
            onTeleportCollision?.Invoke();
            sceneService.OnSceneLoaded += LoadNextScene;
            SetUIState(false);
            //GetComponent<AudioSource>().Play();
            StartCoroutine(sceneService.LoadSceneAsync(SceneType.Loading));
        }

        private async void LoadNextScene()
        {
            sceneService.OnSceneLoaded -= LoadNextScene;
            await Task.Delay(sceneLoadDelay);
            StartCoroutine(sceneService.LoadSceneAsync(nextSceneType));
        }

        private void SetUIState(bool state)
        {
            buttonUIInput.SetButtonInputVisibility(state);
            pauseMenuService.SetPauseButtonState(state);
        }

    }
}