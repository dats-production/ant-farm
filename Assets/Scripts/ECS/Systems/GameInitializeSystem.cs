using DataBase;
using DataBase.Config;
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
        [Inject] private IGameConfig _gameConfig;
        //[Inject] private readonly IGameStateService<GameState> _generalState;
        [Inject] private readonly GetPointFromScene _getPointFromScene;
        private readonly int _antsCount = 6;
        
        private readonly EcsWorld _world;
        public void Init()
        {
            if (LoadGame()) return;
            //CreateCamera();
            //CreateTimer();
            CreateApple();
            CreateWarehouse();
            CreateExit();
            CreateEnter();
        }

        private void CreateApple()
        {
            var entity = _world.NewEntity();
            entity.GetAndFire<AppleComponent>();
            var point = _getPointFromScene.GetPoint("Apple");
            entity.Get<PositionComponent>().Value = point.position;
            var size = _gameConfig.AppleConfig.size;
            entity.Get<SizeComponent>().Value = size;
            entity.Get<UidComponent>().Value = UidGenerator.Next();
            //entity.Get<GatherableComponent>();
            //entity.Get<FoodComponent>().Value = 100;
            //entity.GetAndFire<PrefabComponent>().Value = "Food";
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
            var entity = _world.NewEntity();
            entity.Get<GameStageComponent>().Value = EGameStage.Pause;
            entity.Get<UidComponent>().Value = UidGenerator.Next();
            _world.SetStage(EGameStage.Play);
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