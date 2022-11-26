using ECS.Views.Interfaces;
using UnityEngine;

namespace ECS.Views
{
    public class ChunkView : SelectableView, IPoolable, ISizable
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        public void SetColor(Color color)
        {
            _meshRenderer.material.color = color;
        }

        public void EnableView(bool enable)
        {
            gameObject.SetActive(enable);
        }

        public void SetSize(float size)
        {
            transform.localScale = new Vector3(size, size, size);
        }
    }
}