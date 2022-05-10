using Models.Enum;
using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AudioComponent", menuName = "ScriptableObjects/AudioComponent", order = 3)]
    public class AudioSO : ScriptableObject
    {
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private SceneType sceneType;

        public AudioClip AudioClip => audioClip;
        public SceneType SceneType => sceneType;
    }
}