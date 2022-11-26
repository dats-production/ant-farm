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

namespace ECS.Systems
{
    public class BuildApples : ReactiveSystem<EventAddComponent<AppleComponent>>
    {
        private readonly EcsFilter<ChunkComponent, LinkComponent, IsAvailableComponent> _chunks;
        private readonly EcsFilter<IsAvailableListenerComponent, LinkComponent> _listeners;
        protected override EcsFilter<EventAddComponent<AppleComponent>> ReactiveFilter { get; }
        
        private readonly float chunkSize = 1f;
        protected override void Execute(EcsEntity entity)
        {
            ref var applePos = ref entity.Get<PositionComponent>().Value;
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
                        chunkEntity.Get<SizeComponent>().Value = chunkSize;
                        
                        var chunkView = _chunks.Get2(i).View as ISizable;
                        chunkView.SetSize(chunkSize);

                        ref var chunkPos = ref chunkEntity.Get<PositionComponent>().Value;
                        chunkPos = new Vector3(
                            x * chunkSize - offset,
                            y * chunkSize, 
                            z * chunkSize - offset);
                        chunkPos += applePos;
                        
                        var distanceFromCenter = (chunkPos - center).sqrMagnitude;
                        if (distanceFromCenter < Mathf.Pow(radius, 2))
                            chunkEntity.DelAndFire<IsAvailableComponent>();
                        i++;
                    }
                }
            }

            
        }
    }
}