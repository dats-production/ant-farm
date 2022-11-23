using System;
using System.Threading.Tasks;
using ECS.Components;
using ECS.Components.Events;
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
    public class GatherSystem : ReactiveSystem<ChangeGatherStageComponent>
    {
        private readonly EcsWorld _world;
        
        protected override EcsFilter<ChangeGatherStageComponent> ReactiveFilter { get; }
        //protected override bool DeleteEvent { get; } = false;

        protected override async void Execute(EcsEntity entity)
        {
            var stage = entity.Get<ChangeGatherStageComponent>().Stage;
            entity.Get<GatherComponent>().Stage = stage;
            Debug.Log(entity.Get<GatherComponent>().Stage);

            if (stage == GatherStage.Gather)
            {
                await WaitForSeconds(3, entity);
            }
        }
        private async Task WaitForSeconds(float seconds, EcsEntity entity)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
            if(entity.IsAlive()) entity.SetGatherState(GatherStage.MoveToWarehouse);
        }
    }
}