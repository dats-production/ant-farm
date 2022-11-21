using ECS.Components.Flags;
using ECS.Core.Utils.ReactiveSystem;
using Leopotam.Ecs;
using Scripts.UI.Gather;
using Scripts.UI.Warehouse;
using Signals;
using SimpleUi.Signals;
using Zenject;

namespace ECS.Game.Systems
{
    public class SelectSystem : ReactiveSystem<SelectableComponent>
    {
        [Inject] private SignalBus _signalBus;
        protected override EcsFilter<SelectableComponent> ReactiveFilter { get; }
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
            entity.Get<GatherComponent>();
        }
    }
}