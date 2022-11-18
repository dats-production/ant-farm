using DataBase.Game;
using ECS.DataSave;
using ECS.Game.Components;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Services.Uid;
using Zenject;

namespace ECS.Game.Systems
{
    public class GameInitializeSystem : IEcsInitSystem
    {
        //[Inject] private readonly IGameStateService<GameState> _generalState;
        
        private readonly EcsWorld _world;
        public void Init()
        {
            if (LoadGame()) return;
            CreateCamera();
            CreateTimer();

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
            return true;
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