using System;
using System.Threading.Tasks;
using ECS.Components;
using ECS.Components.Events;
using ECS.Components.Flags;
using ECS.Components.Link;
using ECS.Components.Resources;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Gather
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
            //Debug.Log(entity.Get<GatherComponent>().Stage);

            if (stage != GatherStage.Gather) return;
            await WaitForSeconds(3);
            if (!entity.IsAlive()) return;
            entity.Get<FoodComponent>().Value = 1;
            var gatherableUid = entity.Get<GatherComponent>().GatherableUid;
            var gatherableEnt = _world.GetEntityWithUid(gatherableUid);            
            gatherableEnt.Get<FoodComponent>().Value--;
            
            var gatherableView = gatherableEnt.Get<GatherableComponent>().View;
            var entityPos = entity.Get<LinkComponent>().View.Transform.position;
            gatherableView.GatherChunk(new Vector2(entityPos.x, entityPos.z));
            
            if (gatherableEnt.Get<FoodComponent>().Value <= 0)
            {
                Debug.Log("FOOD is over");
            }
            
            entity.SetGatherState(GatherStage.MoveToEnter);
        }
        private async Task WaitForSeconds(float seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
        }
    }
}