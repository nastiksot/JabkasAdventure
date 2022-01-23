using Modules.Interfaces;
using UnityEngine.SceneManagement;

namespace Services
{ 
    public class SceneService : ISceneService
    { 
        public void LoadSceneAsync(string name)
        {
            SceneManager.LoadSceneAsync(name);
        }

        public void LoadScene(string name)
        { 
            SceneManager.LoadScene(name);
        }  
        public void UnloadSceneAsync(string name)
        {
            SceneManager.UnloadSceneAsync(name);
        }
    }
}