using System;
using System.Collections;
using Models.Enum;

namespace Services.Interfaces
{
    public interface ISceneService
    {
        public SceneType CurrentScene { get;}
        public event Action OnSceneUnloaded;
        public event Action<SceneType> OnSceneLoaded;
        public IEnumerator LoadSceneAsync(SceneType sceneType);
        public IEnumerator UnloadSceneAsync(SceneType sceneType);
    }
}