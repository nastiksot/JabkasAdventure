using Models;
using Modules.Interfaces;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Teleport : MonoBehaviour
    {  
        private ISceneLoader sceneLoader;

        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag(Tags.PLAYER_TAG)) return; 
            //GetComponent<AudioSource>().Play();
            sceneLoader.LoadSceneAsync("MarioLevel");
        }
    }
}