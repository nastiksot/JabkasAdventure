using Factory;
using Modules.InputModule;
using Modules.Interfaces;
using UI;
using UnityEngine;

namespace Zenject
{
    public class BaseSceneInstaller : MonoInstaller, IInitializable
    {
        public InputService InputService;
        public ButtonUIInput ButtonUIInput;
        public PauseMenu PauseMenu;
        public Transform spawnPosition;

        public override void InstallBindings()
        {
            BindIntroLevelInstaller();
            BindInputService();
            BindButtonUIInput();
            BindPlayerFactory();
            BindPauseMenu();
        }

        private void BindPlayerFactory()
        {
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
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
            Container.Bind<PauseMenu>().FromComponentInNewPrefab(PauseMenu).AsSingle().NonLazy();
        }

        private void BindIntroLevelInstaller()
        {
            Container.BindInterfacesAndSelfTo<BaseSceneInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
            var player = Container.Resolve<IPlayerFactory>();
            player.Load();
            player.Create(spawnPosition.position);
        }
    }
}