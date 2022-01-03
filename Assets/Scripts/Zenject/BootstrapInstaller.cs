using Modules.Interfaces;
using Modules.SceneModule;

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
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle().NonLazy();
        }

        private void BindBootstrapInstaller()
        {
            Container.BindInterfacesAndSelfTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }
    }
}
