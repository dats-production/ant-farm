using ECS.Components.Link;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Views;
using Leopotam.Ecs;

namespace ECS.Game.Systems
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