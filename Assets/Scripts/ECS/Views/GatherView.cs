using System;
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
        [SerializeField] private Transform chunksContainer;
        [SerializeField] private ChunkView chunkPrefab;
        
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

        private void Build(int row)
        {
            var chunkSize = chunkPrefab.transform.localScale.x;
            var offset = (row - 1) * chunkSize / 2;
            var radius = row * chunkSize / 2;
            var center = new Vector3(
                transform.position.x,
                transform.position.y + radius,
                transform.position.z);
            for (var y = 0; y < row; y++)
            {
                for (var x = 0; x < row; x++)
                {
                    for (var z = 0; z < row; z++)
                    {
                        var chunk = Instantiate(chunkPrefab, chunksContainer);
                        chunk.transform.localPosition = new Vector3(
                            x * chunkSize - offset,
                            y * chunkSize, 
                            z * chunkSize - offset);
                        
                        var distanceFromCenter = (chunk.transform.position - center).sqrMagnitude;
                        if (distanceFromCenter < radius)
                        {
                            chunk.gameObject.SetActive(true);
                            chunks.Add(chunk);
                        }
                        else
                        {
                            chunk.gameObject.SetActive(false);
                        }                        
                    }
                }
            }
        }
    }
}