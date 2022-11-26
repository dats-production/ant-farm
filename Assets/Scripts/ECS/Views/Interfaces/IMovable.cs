using UnityEngine;

namespace ECS.Views.Interfaces
{
    public interface IMovable
    {
        void SetDestination(Vector3 point);
        bool IsDestinationReached();
    }
}