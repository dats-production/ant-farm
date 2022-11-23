using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace ECS.Views
{
    public interface IGatherable
    {
        void GatherChunk(Vector2 fromVector2);
    }
    public abstract class GatherView : SelectableView, IGatherable
    {
        public Transform menu;
        public Button gatherButton;
        public Transform chunksContainer;
        public ChunkView chunkPrefab;
        private List<ChunkView> chunks = new ();
        
        public override void Link(EcsEntity entity)
        {
            base.Link(entity);
            Build(5);
            //menu.LookAt(Camera.main.transform);
        }

        public void GatherChunk(Vector2 fromVector2)
        {
            var fromVector3 = new Vector3(fromVector2.x, 2, fromVector2.y);
            var minSqrMagnitude = Mathf.Infinity;
            ChunkView closetChunk = default;
            foreach (var chunk in chunks)
            {
                var sqrDistance = (chunk.transform.position - fromVector3).sqrMagnitude;
                if (!(minSqrMagnitude > sqrDistance)) continue;
                minSqrMagnitude = sqrDistance;
                closetChunk = chunk;
            }
            chunks.Remove(closetChunk);
            closetChunk?.gameObject.SetActive(false);
        }

        private void Build(int countPerRow)
        {
            var chunkSize = chunkPrefab.transform.localScale.x;
            var offset = (countPerRow - 1) * chunkSize / 2;
            for (var y = 0; y < countPerRow; y++)
            {
                for (var x = 0; x < countPerRow; x++)
                {
                    for (var z = 0; z < countPerRow; z++)
                    {
                        var chunk = Instantiate(chunkPrefab, chunksContainer);
                        chunks.Add(chunk);
                        chunk.transform.localPosition = new Vector3(
                            x * chunkSize - offset,
                            y * chunkSize, 
                            z * chunkSize - offset);
                    }
                }
            }
        }
    }
}