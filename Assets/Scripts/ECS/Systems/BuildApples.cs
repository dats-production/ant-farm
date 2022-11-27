using System.Collections.Generic;
using DataBase;
using DataBase.Config;
using ECS.Components;
using ECS.Components.Flags;
using ECS.Components.Link;
using ECS.Components.Resources;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components.Listeners.Impl;
using ECS.Utils.Extensions;
using ECS.Views.Interfaces;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace ECS.Systems
{
    public class BuildApples : ReactiveSystem<EventAddComponent<AppleComponent>>
    {
        [Inject] private IGameConfig _gameConfig;
        private readonly EcsFilter<ChunkComponent, LinkComponent>.Exclude<IsActiveComponent> _chunks;
        private readonly EcsFilter<IsAvailableListenerComponent, LinkComponent> _listeners;
        protected override EcsFilter<EventAddComponent<AppleComponent>> ReactiveFilter { get; }

        protected override void Execute(EcsEntity entity)
        {
            entity.Get<ContainerComponent>().Children = new List<Uid>();
            ref var applePos = ref entity.Get<PositionComponent>().Value;
            var chunkSize = _gameConfig.ChunkConfig.size;
            applePos.y += chunkSize / 2;
            var row = (int)entity.Get<SizeComponent>().Value;
            var offset = (row - 1) * chunkSize / 2;
            var radius = row * chunkSize / 2;
            var center = new Vector3(
                applePos.x,
                applePos.y + radius - chunkSize / 2,
                applePos.z);
            
            int i = 0;
            for (var y = 0; y < row; y++)
            {
                for (var x = 0; x < row; x++)
                {
                    for (var z = 0; z < row; z++)
                    {
                        var chunkEntity = _chunks.GetEntity(i);
                        
                        ref var chunkPos = ref chunkEntity.Get<PositionComponent>().Value;
                        chunkPos = new Vector3(
                            x * chunkSize - offset,
                            y * chunkSize, 
                            z * chunkSize - offset);
                        chunkPos += applePos;
                        
                        var distanceFromCenter = (chunkPos - center).sqrMagnitude;
                        if (distanceFromCenter < Mathf.Pow(radius, 2))
                        {
                            var chunkView = _chunks.Get2(i).View as ISizable;
                            chunkView.SetSize(chunkSize);
                            
                            var chunkUid = chunkEntity.Get<UidComponent>().Value;
                            entity.Get<ContainerComponent>().Children.Add(chunkUid);
                            
                            chunkEntity.Get<FoodComponent>().Value = 1;
                            chunkEntity.Get<GatherableComponent>();
                            chunkEntity.Get<OwnerComponent>().Value = entity.Get<UidComponent>().Value;
                            chunkEntity.GetAndFire<IsActiveComponent>();
                        }
                        i++;
                    }
                }
            }
        }
    }
}