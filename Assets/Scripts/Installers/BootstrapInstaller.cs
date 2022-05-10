using Services;
using Services.Interfaces;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public AudioService AudioService;
        
        public override void InstallBindings()
        {
            BindBootstrapInstaller();
            BindAudioService();
            BindSceneLoader();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneService>().To<SceneService>().AsSingle().NonLazy();
        }

        private void BindAudioService()
        {
            Container.Bind<IAudioService>().To<AudioService>().
                FromComponentInNewPrefab(AudioService).
                AsSingle().NonLazy();
        }

        private void BindBootstrapInstaller()
        {
            Container.BindInterfacesAndSelfTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }
    }
}
