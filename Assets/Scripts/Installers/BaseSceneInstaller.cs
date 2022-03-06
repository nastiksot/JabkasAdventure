using Services;
using Services.Interfaces;
using UI;
using UI.Player;
using UI.Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BaseSceneInstaller : MonoInstaller
    {
        public InputService InputService;
        public ButtonUIInput ButtonUIInput;
        public PauseMenuService PauseMenuService;
        
        public PlayerBehaviour PlayerBehaviour;
        public Transform PlayerSpawnPosition;
        
        public override void InstallBindings()
        {
            BindIntroLevelInstaller();
            BindInputService();
            BindButtonUIInput();
            BindPauseMenu();
            BindPlayerBehaviour();
        }

        private void BindPlayerBehaviour()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<PlayerBehaviour>(PlayerBehaviour,
                PlayerSpawnPosition.position, Quaternion.identity, null);
            Container.Bind<IPlayerBehaviour>().To<PlayerBehaviour>().FromInstance(playerInstance).AsSingle().NonLazy();
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