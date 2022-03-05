using Services;
using Services.Interfaces;
using UI;
using Zenject;

namespace Installers
{
    public class BaseSceneInstaller : MonoInstaller
    {
        public InputService InputService;
        public ButtonUIInput ButtonUIInput;
        public PauseMenuService PauseMenuService;

        public override void InstallBindings()
        {
            BindIntroLevelInstaller();
            BindInputService();
            BindButtonUIInput();
            BindPauseMenu();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>().To<InputService>().FromComponentInNewPrefab(InputService).AsSingle();
        }

        private void BindButtonUIInput()
        {
            Container.Bind<ButtonUIInput>().FromComponentInNewPrefab(ButtonUIInput).AsSingle().NonLazy();
        }

        private void BindPauseMenu()
        {
            Container.Bind<IPauseMenuService>().To<PauseMenuService>().FromComponentInNewPrefab(PauseMenuService)
                .AsSingle().NonLazy();
        }

        private void BindIntroLevelInstaller()
        {
            Container.BindInterfacesAndSelfTo<BaseSceneInstaller>().FromInstance(this).AsSingle();
        }
    }
}