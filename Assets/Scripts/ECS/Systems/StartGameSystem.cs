using ECS.Components.Events;
using ECS.Components.Flags;
using ECS.Core.Utils.ReactiveSystem;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class StartGameSystem : ReactiveSystem<ChangeStageComponent>
    {
        private readonly EcsFilter<AntComponent, IsActiveComponent> _ants;
        protected override EcsFilter<ChangeStageComponent> ReactiveFilter { get; }
        protected override bool DeleteEvent => false;
        protected override void Execute(EcsEntity entity)
        {
            //if(entity.Get<ChangeStageComponent>().Value != EGameStage.Play) return;
            Debug.Log(11111);
        }
    }
}