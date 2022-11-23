using System;
using System.Threading.Tasks;
using ECS.Components;
using ECS.Components.Events;
using ECS.Components.Flags;
using ECS.Components.Link;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;

public class CheckDistanseSystem : IEcsUpdateSystem
{
    private readonly EcsFilter<GatherComponent, MovableComponent> _gatheringEntities;
    private readonly EcsFilter<WarehouseComponent, PositionComponent> _warehouses;
    private readonly EcsWorld _world;

    public void Run()
    {
        // if (_gameStage.Get1(0).Value != EGameStage.Play) return;

        foreach (var g in _gatheringEntities)
        {
            var state = _gatheringEntities.Get1(g).Stage;
            var movable = _gatheringEntities.Get2(g).View;
            var entity = _gatheringEntities.GetEntity(g);
            switch (state)
            {
                case GatherStage.MoveToExit:
                    var gatheredUid = entity.Get<GatherComponent>().GatherableUid;
                    var gatheredEntity = _world.GetEntityWithUid(gatheredUid);
                    var gazerPos = gatheredEntity.Get<PositionComponent>().Value;
                    entity.Get<MoveComponent>().Value = gazerPos;
                    if (movable.IsDestinationReached())
                        _gatheringEntities.GetEntity(g).SetGatherState(GatherStage.Gather);
                    break;
                case GatherStage.Gather:
                    break;
                case GatherStage.MoveToWarehouse:
                    var warehousePos = _warehouses.Get2(0).Value;
                    entity.Get<MoveComponent>().Value = warehousePos;
                    if (movable.IsDestinationReached())
                        _gatheringEntities.GetEntity(g).SetGatherState(GatherStage.MoveToExit);
                    break;
                case GatherStage.MoveToGatherable:
                    break;
                case GatherStage.MoveToEnter:
                    break;
                default:
                    Debug.LogError($"There is no Gather State: {state}");
                    break;
            }

        }
    }   
}