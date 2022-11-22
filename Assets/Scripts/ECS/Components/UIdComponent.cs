using DataBase;

namespace ECS.Components
{
    public struct UIdComponent
    {
        public Uid Value;
        public override string ToString() => Value.ToString();
    }
}