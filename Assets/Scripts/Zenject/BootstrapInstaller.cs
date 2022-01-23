using Modules.Interfaces;
using Services;

namespace Zenject
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
