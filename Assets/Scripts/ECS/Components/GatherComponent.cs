using DataBase;

namespace ECS.Components
{
    public struct GatherComponent
    {
        public GatherStage Stage;
        public Uid GatherableUid;
    }

    public enum GatherStage
    {
        MoveToExit,
        MoveToGatherable,
        Gather,
        MoveToEnter,
        MoveToWarehouse
    }
}