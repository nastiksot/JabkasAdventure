using Models.Enum;
using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AudioComponent", menuName = "ScriptableObjects/AudioComponent", order = 3)]
    public class AudioSO : ScriptableObject
    {
        [SerializeField] private string audioClipPath;
        [SerializeField] private SceneType sceneType;

        public string AudioClipPath => audioClipPath;
        public SceneType SceneType => sceneType;
    }
}