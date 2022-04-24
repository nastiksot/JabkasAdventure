using System;
using System.Collections;
using Models.Enum;
using Services.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneService : ISceneService
    {
        private Action onSceneLoaded;
        private Action onSceneUnloaded;

        public SceneType CurrentScene { get; private set; }

        public event Action OnSceneLoaded
        {
            add => onSceneLoaded += value;
            remove => onSceneLoaded -= value;
        }

        public event Action OnSceneUnloaded
        {
            add => onSceneUnloaded += value;
            remove => onSceneUnloaded -= value;
        }

        public IEnumerator LoadSceneAsync(SceneType sceneType)
        {
            CurrentScene = sceneType;
            var asyncLoad = sceneType switch
            {
                SceneType.Menu => SceneManager.LoadSceneAsync(0),
                SceneType.Intro => SceneManager.LoadSceneAsync(1),
                SceneType.Mario => SceneManager.LoadSceneAsync(2),
                SceneType.Final => SceneManager.LoadSceneAsync(3),
                SceneType.Loading => SceneManager.LoadSceneAsync(4, LoadSceneMode.Additive),
                _ => throw new NullReferenceException()
            };

            asyncLoad.allowSceneActivation = false;
            yield return new WaitUntil(() => asyncLoad.progress >= 0.9f);
            onSceneLoaded?.Invoke();
            asyncLoad.allowSceneActivation = true;
        }

        public IEnumerator UnloadSceneAsync(SceneType sceneType)
        {
            var asyncLoad = sceneType switch
            {
                SceneType.Menu => SceneManager.UnloadSceneAsync(0),
                SceneType.Intro => SceneManager.UnloadSceneAsync(1),
                SceneType.Mario => SceneManager.UnloadSceneAsync(2),
                SceneType.Final => SceneManager.UnloadSceneAsync(3),
                SceneType.Loading => SceneManager.UnloadSceneAsync(4),
                _ => throw new NullReferenceException()
            };

            yield return new WaitUntil(() => asyncLoad.progress >= 0.9f);
            onSceneUnloaded?.Invoke();
        }
    }
}