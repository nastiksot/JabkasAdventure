using Models;
using Models.ConstantValues;
using Modules.Interfaces;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Teleport : MonoBehaviour
    {  
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
            sceneService.LoadSceneAsync("MarioLevel");
        }
    }
}