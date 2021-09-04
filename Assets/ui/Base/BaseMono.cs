using System;
using System.Collections;
using UnityEngine;

namespace UI.Base
{
    public class BaseMono : MonoBehaviour
    {
        protected static string TAG = "BaseMono";

        /// <summary>
        /// Start method with delay
        /// </summary>
        /// <param name="second"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected IEnumerator startWithDelay(float second, Action action)
        {
            yield return new WaitForSeconds(second);
            action.Invoke();
        }

        /// <summary>
        /// Start method with next frame
        /// </summary>
        /// <param name="second"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected void startWithNextFrame(Action action)
        {
            StartCoroutine(startWithNextFrameCorutine(action));
        }

        /// <summary>
        /// Start method with next frame coroutine
        /// </summary>
        /// <param name="second"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private IEnumerator startWithNextFrameCorutine(Action action)
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
        protected GameObject InstanceFromPath(string path, string name)
        {
            GameObject gameObject = Instantiate(Resources.Load<GameObject>(path), transform);
            gameObject.name = name;
            return gameObject;
        }

        /// <summary>
        /// Instantiate gameObject from path without name
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected GameObject InstanceFromPath(string path)
        {
            return InstanceFromPath(path, path.Split('/')[path.Split('/').Length - 1]);
        }

        /// <summary>
        /// Custom Debug.Log with class name
        /// </summary>
        /// <param name="message"></param>
        protected void dlog(string message)
        {
            Debug.Log(TAG + ":" + message);
        }

        /// <summary>
        /// Custom Debug.LogError with class name
        /// </summary>
        /// <param name="message"></param>
        protected static void elog(string message)
        {
            Debug.LogError(TAG + ":" + message);
        }

        /// <summary>
        /// Load game object with name
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected GameObject LoadGameObject(string path, string name)
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
        protected GameObject LoadGameObject(string path)
        {
            return LoadGameObject(path, path.Split('/')[path.Split('/').Length - 1]);
        }
    }
}