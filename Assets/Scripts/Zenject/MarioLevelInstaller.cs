using Services;
using Services.Interfaces;
using UI.DataSaver;
using UI.Levels.MarioGame.SwitchBlock;
using UI.Levels.MarioGame.SwitchBlock.Interface;
using UI.Timer;

namespace Zenject
{
    public class MarioLevelInstaller : MonoInstaller, IInitializable
    {
        public StatisticsCollector StatisticsCollector;
        public override void InstallBindings()
        {
            BindMarioLevelInstaller();
            BindSwitcher();
            BindDataService();
            BindTimer();
            BindStatisticCollector();
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
            Container.Bind<StatisticsCollector>().FromComponentInNewPrefab(StatisticsCollector).AsSingle().NonLazy();
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