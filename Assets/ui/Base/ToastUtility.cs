using UnityEngine;

namespace UI.Base
{
    public class ToastUtility : BaseMono
    {
        public static void ShowToast(string text)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

                AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
                AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", text);
                AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
                AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString,
                    Toast.GetStatic<int>("LENGTH_SHORT"));
                toast.Call("show");
            }
            else
            {
                elog(text);
            }
        }
    }
}