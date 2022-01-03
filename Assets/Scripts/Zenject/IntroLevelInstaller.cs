using Modules.InputModule;
using Modules.Interfaces;
using Navigation; 

namespace Zenject
{
    public class IntroLevelInstaller: MonoInstaller
    {
        public InputService InputService;
        public ButtonUIInput ButtonUIInput; 
        public override void InstallBindings()
        {
            BindInputService();
            BindButtonUIInput();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>().To<InputService>().FromComponentInNewPrefab(InputService).AsSingle();
        }

        private void BindButtonUIInput()
        {
            Container.Bind<ButtonUIInput>().FromComponentInNewPrefab(ButtonUIInput).AsSingle().NonLazy();
        }
    }
}