using Leopotam.Ecs;

namespace ECS.Components.Flags
{
    public struct GatherComponent
    {
        public GatherState State;
        public EcsEntity GatheredEntity;
    }

    public enum GatherState
    {
        MoveTo,
        Gather,
        MoveBack
    }
}