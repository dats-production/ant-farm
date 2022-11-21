using System;
using UnityEngine;
using UnityEngine.AI;

namespace ECS.Views
{
    public class AntView : LinkableView
    {
        [SerializeField] private NavMeshAgent agent;

        public void SetDestination(Vector3 destination)
        {
            agent.stoppingDistance = 4;
            agent.destination = destination;

        }

        private void Update()
        {
            Debug.Log(IsDestinationReached());
        }

        public bool IsDestinationReached()
        {
            if (agent.pathPending) return false;
            if (agent.remainingDistance > agent.stoppingDistance) return false;
            return !agent.hasPath || agent.velocity.sqrMagnitude == 0f;
        }
    }
}