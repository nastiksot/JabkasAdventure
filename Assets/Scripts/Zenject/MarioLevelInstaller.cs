using Factory;
using Services;
using Services.Interfaces;
using UI.Levels.MarioGame.SwitchBlock;
using UI.Levels.MarioGame.SwitchBlock.Interface;
using UI.Player;
using UI.Player.Interfaces;
using UI.Timer;
using UnityEngine;

namespace Zenject
{
    public class MarioLevelInstaller : MonoInstaller, IInitializable
    {
        public PlayerBehaviour PlayerBehaviour;
        public Transform playerSpawnPosition;
        public EnemyMarker[] EnemyMarkers;

        public override void InstallBindings()
        {
            BindMarioLevelInstaller();
            BindSwitcher();
            BindDataService();
            BindTimer();
            BindPlayer();
            BindEnemyFactory();
            BindStatistics();
        }

        private void BindEnemyFactory()
        {
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle().NonLazy();
        }

        private void BindSwitcher()
        {
            Container.Bind<ISwitcher>().To<Switcher>().AsSingle().NonLazy();
        }

        private void BindTimer()
        {
            Container.Bind<ITimer>().To<Timer>().AsSingle().NonLazy();
        }
        
        private void BindStatistics()
        {
            Container.Bind<IStatisticService>().To<StatisticService>().AsSingle().NonLazy();
        }

        private void BindDataService()
        {
            Container.Bind<IFileService>().To<FileService>().AsSingle().NonLazy();
        }

        private void BindMarioLevelInstaller()
        {
            Container.BindInterfacesAndSelfTo<MarioLevelInstaller>().FromInstance(this).AsSingle();
        }

        private void BindPlayer()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<PlayerBehaviour>(PlayerBehaviour,
                playerSpawnPosition.position, Quaternion.identity, null);
            Container.Bind<IPlayerBehaviour>().To<PlayerBehaviour>().FromInstance(playerInstance).AsSingle().NonLazy();
        }

        public void Initialize()
        {
            var enemyFactory = Container.Resolve<IEnemyFactory>();
            enemyFactory.Load();

            foreach (var marker in EnemyMarkers)
            {
                enemyFactory.Create(marker.EnemyTransformPoint.position, marker.EnemyType);
            }
        }
    }
}