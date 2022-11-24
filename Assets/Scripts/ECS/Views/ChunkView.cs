using UnityEngine;

namespace ECS.Views
{
    public class ChunkView : SelectableView 
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        public void SetColor(Color color)
        {
            _meshRenderer.material.color = color;
        }
    }
}