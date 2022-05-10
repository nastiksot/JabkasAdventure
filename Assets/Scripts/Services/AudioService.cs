using System.Collections.Generic;
using System.Linq;
using Models.Enum;
using Models.ScriptableObjects;
using Services.Interfaces;
using UnityEngine;

namespace Services
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField] private List<AudioSO> audios;
        [SerializeField] private AudioSource audioSource;

        public float Volume { get; private set; }
        public SceneType CurrentScene { get; private set; }

        public void SetVolume(float volume)
        {
            audioSource.volume = volume;
            Volume = volume;
        }

        public void PlayAudio(SceneType sceneType)
        {
            CurrentScene = sceneType;
            SetAudioClip();
            audioSource.Play();
        }
        
        public void UnPause()
        {
            audioSource.Play();
        }

        public void Pause()
        {
            audioSource.Pause();
        }

        public void MuteAudio()
        {
            Volume = 0;
            audioSource.volume = 0;
            Pause();
        }

        private void SetAudioClip()
        {
            audioSource.clip = audios.FirstOrDefault(x => x.SceneType == CurrentScene)!.AudioClip;
        }
    }
}