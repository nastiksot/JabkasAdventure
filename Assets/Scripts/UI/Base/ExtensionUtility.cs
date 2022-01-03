using System;
using System.Collections;
using UnityEngine;

namespace UI.Base
{
    public static class ExtensionUtility
    {
        /// <summary>
        /// Trying to find object on scene that was inherited from T
        /// </summary>
        /// <param name="result"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void TryToFindObjectOfType<T>(out T result) where T : UnityEngine.Object
        {
            result = UnityEngine.Object.FindObjectOfType<T>();
        }

        public static string TAG = "BaseMono";

        /// <summary>
        /// Start method with delay
        /// </summary>
        /// <param name="second"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerator StartWithDelay(float second, Action action)
        {
            yield return new WaitForSeconds(second);
            action.Invoke();
        }

        

        /// <summary>
        /// Start method with next frame coroutine
        /// </summary>
        /// <param name="second"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerator StartWithNextFrameCorutine(Action action)
        {
            yield return new WaitForEndOfFrame();
            action.Invoke();
        }

        /// <summary>
        /// Instantiate gameObject from path with name
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject InstanceFromPath(string path, string name, Transform transform)
        {
            GameObject gameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>(path), transform);
            gameObject.name = name;
            return gameObject;
        }

        /// <summary>
        /// Instantiate gameObject from path without name
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static GameObject InstanceFromPath(string path, Transform transform)
        {
            return InstanceFromPath(path, path.Split('/')[path.Split('/').Length - 1], transform);
        }

        /// <summary>
        /// Custom Debug.Log with class name
        /// </summary>
        /// <param name="message"></param>
        public static void dlog(string message)
        {
            Debug.Log(TAG + ":" + message);
        }

        /// <summary>
        /// Custom Debug.LogError with class name
        /// </summary>
        /// <param name="message"></param>
        public static void elog(string message)
        {
            Debug.LogError(TAG + ":" + message);
        }

        /// <summary>
        /// Load game object with name
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject LoadGameObject(string path, string name)
        {
            GameObject gameObject = Resources.Load<GameObject>(path);
            gameObject.name = name;
            return gameObject;
        }

        /// <summary>
        /// Load game object without name
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject LoadGameObject(string path)
        {
            return LoadGameObject(path, path.Split('/')[path.Split('/').Length - 1]);
        }
    }
}