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
        private Action onStartLoadingScene;

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

        public event Action OnStartLoadingScene
        {
            add => onStartLoadingScene += value;
            remove => onStartLoadingScene -= value;
        } 

        
        public IEnumerator LoadSceneAsync(SceneType sceneType)
        {
            var asyncLoad = sceneType switch
            {
                SceneType.Menu => SceneManager.LoadSceneAsync(1),
                SceneType.Intro => SceneManager.LoadSceneAsync(1),
                SceneType.Mario => SceneManager.LoadSceneAsync(0),
                SceneType.Final => SceneManager.LoadSceneAsync(0),
                _ => throw new NullReferenceException()
            };
            
            onStartLoadingScene?.Invoke();
            
            asyncLoad.allowSceneActivation = false;
            yield return new WaitUntil(() => asyncLoad.progress >= 0.9f);
            onSceneLoaded?.Invoke();
            asyncLoad.allowSceneActivation = true;
        }

        public IEnumerator UnloadSceneAsync(SceneType sceneType)
        {
            var asyncLoad = sceneType switch
            {
                SceneType.Menu => SceneManager.UnloadSceneAsync(1),
                SceneType.Intro => SceneManager.UnloadSceneAsync(1),
                SceneType.Mario => SceneManager.UnloadSceneAsync(0),
                SceneType.Final => SceneManager.UnloadSceneAsync(0),
                _ => throw new NullReferenceException()
            };
            
            yield return new WaitUntil(() => asyncLoad.progress >= 0.9f);
            onSceneUnloaded?.Invoke();
        }
 
    }
}