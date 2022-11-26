using ECS.Components;
using ECS.Views.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Views
{
    public class ChunkView : SelectableView, IPoolMember, ISizable
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        public override void Link(EcsEntity entity)
        {
            base.Link(entity);
            var hashCode = entity.Get<UidComponent>().Value.GetHashCode();
            var name = GetType().Name.Remove(5) + " #" + hashCode;
            gameObject.name = name;
        }

        public void SetColor(Color color)
        {
            _meshRenderer.material.color = color;
        }

        public void EnableView(bool enable)
        {
            gameObject.SetActive(enable);
        }

        public void SetParent()
        {
            var name = $"[{GetType().Name.Remove(5)}s]";
            transform.SetParent(GameObject.Find(name).transform);
        }

        public void SetSize(float size)
        {
            transform.localScale = new Vector3(size, size, size);
        }
    }
}