using Factory;
using Services;
using Services.Interfaces;
using UI.Levels;
using UI.Levels.MarioGame.SwitchBlock;
using UI.Levels.MarioGame.SwitchBlock.Interface;
using UI.Player;
using UI.Player.Interfaces;
using UI.Timer;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MarioLevelInstaller : MonoInstaller, IInitializable
    {
        public RewardService RewardService;
        public ParticleService ParticleService;
        public PlayerBehaviour PlayerBehaviour;
        public Transform playerSpawnPosition;
        public RewardMarker[] EnemyMarkers;

        public override void InstallBindings()
        {
            BindMarioLevelInstaller();
            BindSwitcher();
            BindTimer();
            BindFileService();
            BindStatisticService();
            BindParticleService();
            BindRewardService();
            BindEnemyFactory();
            BindPlayer();
        }

        private void BindParticleService()
        {
            Container.Bind<IParticleService>().To<ParticleService>().FromComponentInNewPrefab(ParticleService)
                .AsSingle().NonLazy();
        }

        private void BindEnemyFactory()
        {
            Container.Bind<IRewardFactory>().To<RewardFactory>().AsSingle().NonLazy();
        }

        private void BindSwitcher()
        {
            Container.Bind<ISwitcher>().To<Switcher>().AsSingle().NonLazy();
        }

        private void BindTimer()
        {
            Container.Bind<ITimer>().To<Timer>().AsSingle().NonLazy();
        }

        private void BindRewardService()
        {
            Container.Bind<IRewardService>().To<RewardService>().FromComponentInNewPrefab(RewardService).AsSingle()
                .NonLazy();
        }

        private void BindStatisticService()
        {
            Container.Bind<IStatisticService>().To<StatisticService>().AsSingle().NonLazy();
        }

        private void BindFileService()
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
            var enemyFactory = Container.Resolve<IRewardFactory>();
            enemyFactory.Load();

            foreach (var marker in EnemyMarkers)
            {
                enemyFactory.Create(marker.RewardTransformPoint.position, marker.RewardType);
            }
        }
    }
}