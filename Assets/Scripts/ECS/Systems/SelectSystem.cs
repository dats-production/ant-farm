using DataBase;
using ECS.Components;
using ECS.Components.Flags;
using ECS.Components.Link;
using ECS.Components.Resources;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Signals;
using SimpleUi.Signals;
using UI.Gather;
using UI.GatherWorld;
using UI.Warehouse;
using UnityEngine;
using Zenject;

namespace ECS.Systems
{
    public class SelectSystem : ReactiveSystem<EventAddComponent<SelectableComponent>>
    {
        [Inject] private SignalBus _signalBus;
        private readonly EcsWorld _world;
        private readonly EcsFilter<AntComponent> _ants;
        protected override EcsFilter<EventAddComponent<SelectableComponent>> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            var view = entity.Get<SelectableComponent>().View;
            var uid = entity.Get<UidComponent>().Value;
            view.SetMouseDownAction(OnMouseDown);
        }

        private void OnMouseDown(Uid uid)
        {
            _signalBus.BackWindow();
            var selectedEntity = _world.GetEntityWithUid(uid);
            if(selectedEntity.Has<GatherableComponent>())
            {
                _signalBus.OpenWindow<GatherWindow>();
                //var ownerPos = _world.GetOwnerEntity(selectedEntity).Get<PositionComponent>().Value;
                //_signalBus.Fire(new SignalSetPosition(ownerPos));
                _signalBus.Fire(new SignalSelect(uid, OnGather));
            }
            else if (selectedEntity.Has<WarehouseComponent>())
            {
                _signalBus.OpenWindow<WarehouseWindow>();
            }
        }      
        
        private void OnGather(Uid uid)
        {
            foreach (var a in _ants)
            {
                _ants.GetEntity(a).SetGatherState(GatherStage.MoveToExit);
                _ants.GetEntity(a).Get<GatherComponent>().GatherableUid = uid;
            }
        }
    }
}