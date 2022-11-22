using ECS.Components.Flags;
using ECS.Components.Link;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Scripts.UI.Gather;
using Scripts.UI.Warehouse;
using Signals;
using SimpleUi.Signals;
using Zenject;

namespace ECS.Game.Systems
{
    public class SelectSystem : ReactiveSystem<EventAddComponent<SelectableComponent>>
    {
        [Inject] private SignalBus _signalBus;

        private readonly EcsFilter<AntComponent> _ants;
        protected override EcsFilter<EventAddComponent<SelectableComponent>> ReactiveFilter { get; }
        protected override void Execute(EcsEntity entity)
        {
            var view = entity.Get<SelectableComponent>().View;
            view.SetMouseDownAction(entity, OnMouseDown);
        }

        private void OnMouseDown(EcsEntity selectedEntity)
        {
            if(selectedEntity.Has<ExitComponent>())
            {
                _signalBus.OpenWindow<GatherWindow>();
                _signalBus.Fire(new SignalSelect(selectedEntity, OnGather));
            }
            else if (selectedEntity.Has<WarehouseComponent>())
            {
                _signalBus.OpenWindow<WarehouseWindow>();
            }
        }      
        
        private void OnGather(EcsEntity entity)
        {
            foreach (var a in _ants)
            {
                _ants.GetEntity(a).GetAndFire<GatherComponent>().State = GatherState.MoveTo;
                _ants.GetEntity(a).GetAndFire<GatherComponent>().GatheredEntity = entity;
            }
        }
    }
}