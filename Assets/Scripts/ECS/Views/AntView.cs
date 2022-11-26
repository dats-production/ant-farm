using ECS.Components;
using ECS.Views.Interfaces;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace ECS.Views
{
    public class AntView : LinkableView, IMovable, IPoolable
    {
        [SerializeField] private NavMeshAgent agent;

        public override void Link(EcsEntity entity)
        {
            base.Link(entity);
            var hashCode = entity.Get<UidComponent>().Value.GetHashCode();
            var name = GetType().Name.Remove(3) + " #" + hashCode;
            gameObject.name = name;
            
            agent.speed = 15;
            agent.stoppingDistance = 3;
            agent.acceleration = 100;
            agent.angularSpeed = 1720;
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
            //if(agent == null) return false;
            if (agent.pathPending) return false;
            if (agent.remainingDistance > agent.stoppingDistance) return false;
            if (!agent.hasPath) return false;
            agent.ResetPath();
            return true;
        }

        public void EnableView(bool enable)
        {
            gameObject.SetActive(enable);
        }

        public void SetParent()
        {
            var name = $"[{GetType().Name.Remove(3)}s]";
            transform.SetParent(GameObject.Find(name).transform);
        }
    }
}