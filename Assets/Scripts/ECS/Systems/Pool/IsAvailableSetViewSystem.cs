using ECS.Components.Flags;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components.Flags;
using ECS.Game.Components.Listeners.Impl;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Linked
{
    public class IsAvailableSetViewSystem : ReactiveSystem<EventAddComponent<IsAvailableComponent>, EventRemoveComponent<IsAvailableComponent>>
    {
        protected override EcsFilter<EventAddComponent<IsAvailableComponent>> ReactiveFilter { get; }
        protected override EcsFilter<EventRemoveComponent<IsAvailableComponent>> ReactiveFilter2 { get; }
        protected override void Execute(EcsEntity entity, bool added)
        {
            entity.Get<IsAvailableListenerComponent>().Value?.Invoke(added);
        }
    }
}