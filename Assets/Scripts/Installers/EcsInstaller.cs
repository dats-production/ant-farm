using ECS;
using ECS.Game.Systems;
using ECS.Game.Systems.GameDay;
using ECS.Game.Systems.Linked;
using ECS.Systems;
using Game.Utils.MonoBehUtils;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class EcsInstaller : MonoInstaller
    {
        [SerializeField] private GetPointFromScene getPointFromScene;
        
        public override void InstallBindings()
        {
            Container.Bind<GetPointFromScene>().FromInstance(getPointFromScene).AsSingle();
            Container.BindInterfacesAndSelfTo<EcsWorld>().AsSingle().NonLazy();
            BindSystems();
            Container.BindInterfacesTo<EcsMainBootstrap>().AsSingle();

        }

        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<IsAvailableSetViewSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameInitializeSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InstantiateSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<PositionRotationTranslateSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameTimerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GamePauseSystem>().AsSingle();
            //Container.BindInterfacesAndSelfTo<SaveGameSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<AntMoveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SelectSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GatherSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameStageSystem>().AsSingle();        //always must been last
            Container.BindInterfacesAndSelfTo<CleanUpSystem>().AsSingle();          //must been latest than last!
        }       
    }
}