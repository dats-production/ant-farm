using System;
using ECS.Components.Flags;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Game.Components;
using ECS.Views;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Game.Systems
{
    public class SelectSystem : ReactiveSystem<SelectComponent>
    {
        protected override EcsFilter<SelectComponent> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            var view = entity.Get<SelectComponent>().View;
            view.SetMouseDownAction(OnMouseDown);
        }

        private void OnMouseDown()
        {
            Debug.Log(111);
        }
    }
}