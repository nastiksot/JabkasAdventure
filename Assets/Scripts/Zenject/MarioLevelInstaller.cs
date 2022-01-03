using Factory;
using Levels.MarioGame.SwitchBlock;
using Levels.MarioGame.SwitchBlock.Interface;
using Modules.InputModule;
using Modules.Interfaces; 

namespace Zenject
{
    public class MarioLevelInstaller : MonoInstaller, IInitializable
    { 

        public override void InstallBindings()
        {
            BindMarioLevelInstaller();
            BindSwitcher();
        } 
        
        private void BindSwitcher()
        {
            Container.Bind<ISwitcher>().To<Switcher>().AsSingle().NonLazy(); 
        }
  
        private void BindMarioLevelInstaller()
        {
            Container.BindInterfacesAndSelfTo<MarioLevelInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
           
        }
    }
}