using Models.Enum;

namespace Services.Interfaces
{
    public interface IAudioService
    {
        public SceneType CurrentScene { get;}
        public float Volume { get; }
        public void SetVolume(float volume);
        public void PlayAudio(SceneType sceneType);
        public void UnPause();
        public void Pause();

        public void MuteAudio();
    }
}