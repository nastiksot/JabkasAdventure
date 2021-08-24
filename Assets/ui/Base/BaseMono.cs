using System;
using System.Collections;
using UnityEngine;

namespace UI.Base
{
    public class BaseMono : MonoBehaviour
    {
        protected static string TAG = "BaseMono";
  
        protected IEnumerator startWithDelay(float second, Action action)
        {
            yield return new WaitForSeconds(second);
            action.Invoke();
        }
    

        protected void startWithNextFrame(Action action)
        {
            StartCoroutine(startWithNextFrameCorutine(action));
        }


        private IEnumerator startWithNextFrameCorutine(Action action)
        {
            yield return new WaitForEndOfFrame();
            action.Invoke();
        }

        protected GameObject InstanceFromPath(string path, string name)
        {
            GameObject gameObject = Instantiate(Resources.Load<GameObject>(path), transform);
            gameObject.name = name;
            return gameObject;
        }

        protected GameObject InstanceFromPath(string path)
        {
            return InstanceFromPath(path, path.Split('/')[path.Split('/').Length - 1]);
        }

        protected void dlog(string message)
        {
            Debug.Log(TAG + ":" + message); 
        }

        protected static void elog(string message)
        { 
            Debug.LogError(TAG + ":" + message);
        }

        protected GameObject LoadGameObject(string path, string name)
        {
            GameObject gameObject = Resources.Load<GameObject>(path);
            gameObject.name = name;
            return gameObject;
        }

        protected GameObject LoadGameObject(string path)
        {
            return LoadGameObject(path, path.Split('/')[path.Split('/').Length - 1]);
        }


  
 
    }
}