using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components;
using ECS.Views;
using Leopotam.Ecs;

namespace ECS.Game.Systems
{
    public class AntMoveSystem : ReactiveSystem<MoveComponent>
    {
        protected override EcsFilter<MoveComponent> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            //if (_gameStage.Get1(0).Value != EGameStage.Play) return;

            var view = entity.Get<LinkComponent>().View as AntView;
            var target = entity.Get<MoveComponent>().Value;
            view?.SetDestination(target);
        }
    }
}