﻿using ECS.Components;
using ECS.Components.Link;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Utils.Extensions;
using ECS.Views;
using Leopotam.Ecs;
using Services.SpawnService;
using Zenject;

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
        }
    }
}