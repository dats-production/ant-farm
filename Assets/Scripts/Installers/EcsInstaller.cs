using ECS.Game.Systems;
using ECS.Game.Systems.GameDay;
using ECS.Game.Systems.Linked;
using Leopotam.Ecs;
using Zenject;

namespace ECS.Installers
{
    public class EcsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EcsWorld>().AsSingle().NonLazy();
            BindSystems();
            Container.BindInterfacesTo<EcsMainBootstrap>().AsSingle();

        }

        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<IsAvailableSetViewSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameInitializeSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InstantiateSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameTimerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GamePauseSystem>().AsSingle();
            //Container.BindInterfacesAndSelfTo<SaveGameSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameStageSystem>().AsSingle();        //always must been last
            Container.BindInterfacesAndSelfTo<CleanUpSystem>().AsSingle();          //must been latest than last!
        }       
    }
}