using Modules; 

namespace Zenject
{
    public class BootstrapInstaller : MonoInstaller 
    { 
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle().NonLazy();
        }
 
    }
}
