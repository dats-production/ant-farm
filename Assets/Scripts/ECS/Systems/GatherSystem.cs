using ECS.Components.Flags;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class GatherSystem : ReactiveSystem<GatherComponent>
    {
        private readonly EcsFilter<AntComponent, LinkComponent> _ants;
        protected override EcsFilter<GatherComponent> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            var gazerPos = entity.Get<LinkComponent>().View.Transform.position;
            foreach (var ant in _ants)
            {
                _ants.GetEntity(ant).Get<MoveComponent>().Value = gazerPos;
            }
        }
    }
}