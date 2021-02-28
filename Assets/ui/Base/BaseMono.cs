using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMono : MonoBehaviour
{
    protected string TAG = "BaseMono";


    protected IEnumerator startWithDelay(int second, Action action)
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
        try
        {
            _ShowAndroidToastMessage(message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    protected void elog(string message)
    {
        try
        {
            _ShowAndroidToastMessage(message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

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


    private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }

    protected void Awake()
    {
    }
}