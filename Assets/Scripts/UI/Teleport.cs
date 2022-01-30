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
        private ISceneService sceneService;

        [Inject]
        public void Construct(ISceneService sceneService)
        {
            this.sceneService = sceneService;
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return; 
            //GetComponent<AudioSource>().Play();
            sceneService.LoadSceneAsync(nextSceneType);
        }
    }
}