using ECS.Components.Flags;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components.Listeners.Impl;
using Leopotam.Ecs;

namespace ECS.Systems.Pool
{
    public class IsAvailableSetViewSystem : ReactiveSystem<EventAddComponent<IsActiveComponent>, EventRemoveComponent<IsActiveComponent>>
    {
        protected override EcsFilter<EventAddComponent<IsActiveComponent>> ReactiveFilter { get; }
        protected override EcsFilter<EventRemoveComponent<IsActiveComponent>> ReactiveFilter2 { get; }
        protected override void Execute(EcsEntity entity, bool added)
        {
            entity.Get<IsAvailableListenerComponent>().Value?.Invoke(added);
        }
    }
}