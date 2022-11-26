using DataBase;
using ECS.Components.Events;
using ECS.Components.Flags;
using ECS.Components.Link;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class StartGameSystem : ReactiveSystem<ChangeStageComponent>
    {
        private readonly EcsFilter<AntComponent, IsAvailableComponent> _ants;
        protected override EcsFilter<ChangeStageComponent> ReactiveFilter { get; }
        protected override bool DeleteEvent => false;
        protected override void Execute(EcsEntity entity)
        {
            //if(entity.Get<ChangeStageComponent>().Value != EGameStage.Play) return;
            Debug.Log(11111);
        }
    }
}