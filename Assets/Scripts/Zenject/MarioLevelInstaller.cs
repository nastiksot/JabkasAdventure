using System.Collections.Generic;
using Factory;
using Services;
using Services.Interfaces;
using UI.DataSaver;
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
        public StatisticsCollector StatisticsCollector;
        public PlayerBehaviour PlayerBehaviour;
        public EnemyMarker[] EnemyMarker;
        public Transform playerSpawnPosition;

        public override void InstallBindings()
        {
            BindSwitcher();
            BindDataService();
            BindTimer();
            BindStatisticCollector();
            BindPlayer();
            BindMarioLevelInstaller();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
        }

        private void BindSwitcher()
        {
            Container.Bind<ISwitcher>().To<Switcher>().AsSingle().NonLazy();
        }

        private void BindTimer()
        {
            Container.Bind<ITimer>().To<Timer>().AsSingle().NonLazy();
        }

        private void BindDataService()
        {
            Container.Bind<IDataService>().To<DataService>().AsSingle().NonLazy();
        }

        private void BindStatisticCollector()
        {
            Container.BindInterfacesAndSelfTo<StatisticsCollector>().FromComponentInNewPrefab(StatisticsCollector)
                .AsSingle().NonLazy();
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
            var enemyFactory =  Container.Resolve<IEnemyFactory>();
            enemyFactory.Load();
            foreach (var marker in EnemyMarker)
            {
                enemyFactory.Create(marker.transform.position);
            }
        }
    }
}