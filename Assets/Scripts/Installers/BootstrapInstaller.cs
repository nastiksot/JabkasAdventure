using Services;
using Services.Interfaces;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            BindBootstrapInstaller();
            BindSceneLoader();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneService>().To<SceneService>().AsSingle().NonLazy();
        }

        private void BindBootstrapInstaller()
        {
            Container.BindInterfacesAndSelfTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }
    }
}
