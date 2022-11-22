using System;
using System.Threading.Tasks;
using ECS.Components.Flags;
using ECS.Components.Link;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class GatherSystem : ReactiveSystem<EventAddComponent<GatherComponent>>
    {
        private readonly EcsFilter<WarehouseComponent, PositionComponent> _warehouses;
        protected override EcsFilter<EventAddComponent<GatherComponent>> ReactiveFilter { get; }
        //protected override bool DeleteEvent { get; } = false;

        protected override async void Execute(EcsEntity entity)
        {
            Debug.Log(entity.Get<GatherComponent>().State);
            var state = entity.Get<GatherComponent>().State;

            switch (state)
            {
                case GatherState.MoveTo:
                    var gatheredEntity = entity.Get<GatherComponent>().GatheredEntity;
                    var gazerPos = gatheredEntity.Get<PositionComponent>().Value;
                    entity.Get<MoveComponent>().Value = gazerPos;
                    break;
                case GatherState.Gather:
                    await WaitForSeconds(2);
                    entity.GetAndFire<GatherComponent>().State = GatherState.MoveBack;
                    break;
                case GatherState.MoveBack:
                    var warehousePos = _warehouses.Get2(0).Value;
                    entity.Get<MoveComponent>().Value = warehousePos;
                    break;
                default:
                    Debug.LogError($"There is no Gather State: {state}");
                    break;
            }
        }

        private async Task WaitForSeconds(float seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
        }
    }
}