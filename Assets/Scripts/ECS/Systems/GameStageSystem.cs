using ECS.Components;
using ECS.Components.Events;
using ECS.Core.Utils.ReactiveSystem;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class GameStageSystem : ReactiveSystem<ChangeStageComponent>
    {
        protected override EcsFilter<ChangeStageComponent> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            ref var stage = ref entity.Get<ChangeStageComponent>().Value;
            entity.Get<GameStageComponent>().Value = stage;
        }
    }
}