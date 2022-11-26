using ECS.Components;
using ECS.Components.Flags;
using ECS.Components.Link;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components.Listeners.Impl;
using ECS.Utils.Extensions;
using ECS.Views;
using ECS.Views.Interfaces;
using Leopotam.Ecs;
using Services.SpawnService;
using Zenject;
using IPoolable = ECS.Views.Interfaces.IPoolable;

namespace ECS.Systems
{
    public class InstantiateSystem : ReactiveSystem<EventAddComponent<PrefabComponent>>
    {
        [Inject] private readonly ISpawnService<EcsEntity, ILinkable> _spawnService;
        protected override EcsFilter<EventAddComponent<PrefabComponent>> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            var linkable = _spawnService.Spawn(entity);
            linkable?.Link(entity);
            entity.Get<LinkComponent>().View = linkable;

            if (linkable is ISelectable selectable) 
                entity.GetAndFire<SelectableComponent>().View = selectable;
            
            if (linkable is IMovable movable) 
                entity.Get<MovableComponent>().View = movable;
            
            if(linkable is IGatherable gatherable)
                entity.Get<GatherableComponent>().View = gatherable;

            if (entity.Has<IsAvailableListenerComponent>())
            {   
                var poolView = linkable as IPoolable;
                entity.Get<IsAvailableListenerComponent>().Value += (x) =>
                {
                    poolView.EnableView(!x);
                };
            }
        }
    }
}