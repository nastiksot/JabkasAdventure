using System;
using System.Collections;
using Models.Enum;

namespace Services.Interfaces
{
    public interface ISceneService
    {
        public event Action OnSceneUnloaded;
        public event Action OnSceneLoaded;
        public event Action OnStartLoadingScene;
        public IEnumerator LoadSceneAsync(SceneType sceneType);
        public IEnumerator UnloadSceneAsync(SceneType sceneType);
    }
}