using System;
using System.Threading.Tasks;
using ECS.Components;
using ECS.Components.Events;
using ECS.Components.Flags;
using ECS.Components.Link;
using ECS.Components.Resources;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;

public class GatherUpdateSystem : IEcsUpdateSystem
{
    private readonly EcsFilter<GatherComponent, MovableComponent> _gatheringEntities;
    private readonly EcsFilter<EnterComponent, PositionComponent> _enter;
    private readonly EcsFilter<ExitComponent, PositionComponent> _exit;
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
            var entityTr = entity.Get<LinkComponent>().View.Transform;
            switch (state)
            {
                case GatherStage.MoveToExit:
                    entity.Get<MoveComponent>().Value = GetPassWayPos(PassWay.Exit);
                    if (!movable.IsDestinationReached()) break;
                    entityTr.position = GetPassWayPos(PassWay.Enter);
                    _gatheringEntities.GetEntity(g).SetGatherState(GatherStage.MoveToGatherable);
                    break;
                case GatherStage.MoveToGatherable:
                    var gatheredUid = entity.Get<GatherComponent>().GatherableUid;
                    var gatheredEntity = _world.GetEntityWithUid(gatheredUid);
                    var gazerPos = gatheredEntity.Get<PositionComponent>().Value;
                    entity.Get<MoveComponent>().Value = gazerPos;
                    if (!movable.IsDestinationReached()) break;
                    _gatheringEntities.GetEntity(g).SetGatherState(GatherStage.Gather);
                    break;
                case GatherStage.Gather:
                    break;
                case GatherStage.MoveToEnter:
                    entity.Get<MoveComponent>().Value = GetPassWayPos(PassWay.Enter);
                    if (!movable.IsDestinationReached()) break;
                    entityTr.position = GetPassWayPos(PassWay.Exit);
                    _gatheringEntities.GetEntity(g).SetGatherState(GatherStage.MoveToWarehouse);
                    break;
                case GatherStage.MoveToWarehouse:
                    var warehousePos = _warehouses.Get2(0).Value;
                    entity.Get<MoveComponent>().Value = warehousePos;
                    if (!movable.IsDestinationReached()) break;
                    _gatheringEntities.GetEntity(g).SetGatherState(GatherStage.MoveToExit);
                    foreach (var w in _warehouses)
                    {
                        var count = entity.Get<FoodComponent>().Value;
                        _warehouses.GetEntity(w).Get<FoodComponent>().Value += count;
                    }
                    entity.Del<FoodComponent>();
                    break;
                default:
                    Debug.LogError($"There is no Gather State: {state}");
                    break;
            }
        }
    }

    private Vector3 GetPassWayPos(PassWay passWay)
    {
        switch (passWay)
        {
            case PassWay.Enter:
                foreach (var e in _enter)
                {
                    var enterPos = _enter.Get2(e).Value;
                    return enterPos;
                }
                break;
            case PassWay.Exit:
                foreach (var e in _exit)
                {
                    var exitPos = _exit.Get2(e).Value;
                    return exitPos;
                }
                break;
            default:
                Debug.LogError($"There is no passDis: {passWay}");
                break;
        }
        return default;
    }
}
public enum PassWay
{
    Enter,
    Exit
}