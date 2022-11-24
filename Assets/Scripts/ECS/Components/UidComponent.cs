using DataBase;

namespace ECS.Components
{
    public struct UidComponent
    {
        public Uid Value;
        public override string ToString() => Value.ToString();
    }
}