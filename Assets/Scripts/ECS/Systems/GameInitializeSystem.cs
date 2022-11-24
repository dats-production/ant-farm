using DataBase;
using ECS.Components;
using ECS.Components.Flags;
using ECS.Components.Resources;
using ECS.Game.Components;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Services.Uid;
using Utils.MonoBehUtils;
using Zenject;

namespace ECS.Systems
{
    public class GameInitializeSystem : IEcsInitSystem
    {
        //[Inject] private readonly IGameStateService<GameState> _generalState;
        [Inject] private readonly GetPointFromScene _getPointFromScene;
        private readonly int _antsCount = 6;
        
        private readonly EcsWorld _world;
        public void Init()
        {
            if (LoadGame()) return;
            //CreateCamera();
            CreateTimer();
            CreateAnt(_antsCount);
            CreateFood();
            CreateWarehouse();
            CreateExit();
            CreateEnter();
        }

        private void CreateFood()
        {
            var entity = _world.NewEntity();
            entity.Get<FoodComponent>().Value = 100;
            entity.Get<UidComponent>().Value = UidGenerator.Next();
            entity.GetAndFire<PrefabComponent>().Value = "Food";
            var point = _getPointFromScene.GetPoint("Food");
            entity.Get<PositionComponent>().Value = point.position;
        }


        private void CreateAnt(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var entity = _world.NewEntity();
                entity.Get<AntComponent>();
                entity.Get<UidComponent>().Value = UidGenerator.Next();
                entity.GetAndFire<PrefabComponent>().Value = "Ant";                
            }
        }
        
        private void CreateWarehouse()
        {
            var entity = _world.NewEntity();
            entity.Get<WarehouseComponent>();
            entity.Get<UidComponent>().Value = UidGenerator.Next();
            entity.GetAndFire<PrefabComponent>().Value = "Warehouse";
            var point = _getPointFromScene.GetPoint("Warehouse");
            entity.Get<PositionComponent>().Value = point.position;
        }
        
        private void CreateEnter()
        {
            var entity = _world.NewEntity();
            entity.Get<EnterComponent>();
            entity.Get<UidComponent>().Value = UidGenerator.Next();
            entity.GetAndFire<PrefabComponent>().Value = "Enter";
            var point = _getPointFromScene.GetPoint("Enter");
            entity.Get<PositionComponent>().Value = point.position;
        }
        
        private void CreateExit()
        {
            var entity = _world.NewEntity();
            entity.Get<ExitComponent>();
            entity.Get<UidComponent>().Value = UidGenerator.Next();
            entity.GetAndFire<PrefabComponent>().Value = "Exit";
            var point = _getPointFromScene.GetPoint("Exit");
            entity.Get<PositionComponent>().Value = point.position;
        }

        private bool LoadGame()
        {
            _world.NewEntity().Get<GameStageComponent>().Value = EGameStage.Pause;
            // var gState = _generalState.GetData();
            // if (gState.SaveState.IsNullOrEmpty()) return false;
            // foreach (var state in gState.SaveState)
            // {
            //     var entity =_world.NewEntity();
            //     state.ReadState(entity);
            // }
            //return true;
            return false;
        }

        private void CreateTimer()
        {
            var entity = _world.NewEntity();
            entity.Get<TimerComponent>();
            entity.Get<UidComponent>().Value = UidGenerator.Next();
        }
        
        private void CreateCamera()
        {
            _world.CreateCamera();
        }
    }
}