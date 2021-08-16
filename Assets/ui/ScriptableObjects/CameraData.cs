using System;
using UnityEngine;

namespace UI.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CameraData", order = 1)]
    public class CameraData : ScriptableObject
    {
       [Space (6f)] public Vector2Values XValues;
       [Space (6f)] public Vector2Values YValues;
       [Space (6f)] public float cameraSize;
    }


    [Serializable]
    public struct Vector2Values
    {   
        public float MIN;
        public float MAX;

        public Vector2Values(Vector2Values newData)
        {
            MIN = newData.MIN;
            MAX = newData.MAX; 
        }
    }

}