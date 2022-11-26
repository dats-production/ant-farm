using ECS.Components.Events;
using ECS.Components.Flags;
using ECS.Components.Link;
using ECS.Core.Utils.ReactiveSystem;
using ECS.Views.Interfaces;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class StartGameSystem : ReactiveSystem<ChangeStageComponent>
    {
        private readonly EcsFilter<AntComponent, LinkComponent>.Exclude<IsActiveComponent> _ants;
        protected override EcsFilter<ChangeStageComponent> ReactiveFilter { get; }
        protected override bool DeleteEvent => false;
        protected override void Execute(EcsEntity entity)
        {
            //if(entity.Get<ChangeStageComponent>().Value != EGameStage.Play) return;
            var startAntCount = 3;

            for (var i = 0; i < startAntCount; i++)
            {
                foreach (var a in _ants)
                {
                    var view = _ants.Get2(a).View as IPoolMember;
                    view.EnableView(true);
                    break;
                }
            }
        }
    }
}