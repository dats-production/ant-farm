using ECS.Components;
using ECS.Components.Link;
using ECS.Core.Utils.ReactiveSystem;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class MoveSystem : ReactiveSystem<MoveComponent>
    {
        protected override EcsFilter<MoveComponent> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            //if (_gameStage.Get1(0).Value != EGameStage.Play) return;

            var view = entity.Get<MovableComponent>().View;
            var target = entity.Get<MoveComponent>().Value;
            view?.SetDestination(target);
        }
    }
}