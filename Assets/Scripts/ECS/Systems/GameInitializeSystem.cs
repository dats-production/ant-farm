using DataBase.Game;
using ECS.Components.Flags;
using ECS.DataSave;
using ECS.Game.Components;
using ECS.Utils.Extensions;
using Game.Utils.MonoBehUtils;
using Leopotam.Ecs;
using Services.Uid;
using UnityEngine;
using Zenject;

namespace ECS.Game.Systems
{
    public class GameInitializeSystem : IEcsInitSystem
    {
        //[Inject] private readonly IGameStateService<GameState> _generalState;
        [Inject] private readonly GetPointFromScene _getPointFromScene;
        
        private readonly EcsWorld _world;
        public void Init()
        {
            if (LoadGame()) return;
            //CreateCamera();
            CreateTimer();
            CreateAnt();
            CreateWarehouse();
            CreateExit();
        }

        private void CreateAnt()
        {
            var entity = _world.NewEntity();
            entity.Get<AntComponent>();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.GetAndFire<PrefabComponent>().Value = "Ant";
        }
        
        private void CreateWarehouse()
        {
            var entity = _world.NewEntity();
            entity.Get<WarehouseComponent>();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.GetAndFire<PrefabComponent>().Value = "Warehouse";
            var point = _getPointFromScene.GetPoint("Warehouse");
            entity.Get<PositionComponent>().Value = point.position;
        }
        
        private void CreateExit()
        {
            var entity = _world.NewEntity();
            entity.Get<ExitComponent>();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
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
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
        }
        
        private void CreateCamera()
        {
            _world.CreateCamera();
        }
    }
}