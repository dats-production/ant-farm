using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace ECS.Views
{
    public interface IMovable
    {
        void SetDestination(Vector3 point);
        bool IsDestinationReached();
    }
    
    public class AntView : LinkableView, IMovable
    {
        [SerializeField] private NavMeshAgent agent;


        public override void Link(EcsEntity entity)
        {
            base.Link(entity);
            agent.speed = 15;
            agent.stoppingDistance = 6;
            agent.acceleration = 30;
            agent.angularSpeed = 720;
        }

        public void SetDestination(Vector3 point)
        {

            agent.SetDestination(point);
        }

        private void Update()
        {
            IsDestinationReached();
        }

        public bool IsDestinationReached()
        {
            if (agent.pathPending) return false;
            if (agent.remainingDistance > agent.stoppingDistance) return false;
            if (!agent.hasPath) return false;
            agent.ResetPath();
            return true;
        }
    }
}