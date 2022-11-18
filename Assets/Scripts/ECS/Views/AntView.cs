using UnityEngine;
using UnityEngine.AI;

namespace ECS.Views
{
    public class AntView : LinkableView
    {
        [SerializeField] private NavMeshAgent agent;

        public void SetDestination(Vector3 destination)
        {
            agent.destination = destination;
        }
    }
}