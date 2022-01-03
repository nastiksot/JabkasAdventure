using UnityEngine;

namespace Utility
{
    public class ToastUtility  
    {
        /// <summary>
        /// Show Android java toasts
        /// </summary>
        /// <param name="text"></param>
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
                ExtensionUtility.elog(text);
            }
        }
    }
}