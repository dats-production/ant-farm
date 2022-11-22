
using ECS.Components.Flags;
using ECS.Components.Link;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;

public class CheckDistanseSystem : IEcsUpdateSystem
{
    private readonly EcsFilter<GatherComponent, MovableComponent> _gatheringEntities;
    private readonly EcsWorld _world;

    public void Run()
    {
        // if (_gameStage.Get1(0).Value != EGameStage.Play) return;

        foreach (var g in _gatheringEntities)
        {
            ref var state = ref _gatheringEntities.Get1(g).State;
            var movable = _gatheringEntities.Get2(g).View;
            switch (state)
            {
                case GatherState.MoveTo:
                    if (movable.IsDestinationReached())
                        _gatheringEntities.GetEntity(g).GetAndFire<GatherComponent>().State = GatherState.Gather;
                    break;
                case GatherState.MoveBack:
                    if (movable.IsDestinationReached())
                        _gatheringEntities.GetEntity(g).GetAndFire<GatherComponent>().State = GatherState.MoveTo;
                    break;
                case GatherState.Gather:
                default:
                    return;
            }
        }
    }
}


