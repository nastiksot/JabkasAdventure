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
            BindPlayerStomper();
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

        private void BindPlayerStomper()
        {
            var player = Container.Resolve<IPlayerBehaviour>();
            player.InitializeStomper();
        }

        public void Initialize()
        {
            var rewardFactory = Container.Resolve<IRewardFactory>();
            rewardFactory.Load();

            foreach (var marker in EnemyMarkers)
            {
                rewardFactory.Create(marker.RewardTransformPoint.position, marker.RewardType);
            }
        }
    }
}