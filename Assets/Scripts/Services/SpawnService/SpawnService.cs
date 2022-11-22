using System;
using DataBase;
using ECS.Components;
using ECS.Utils;
using ECS.Views;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace Services.SpawnService
{
    public class SpawnService : ISpawnService<EcsEntity, ILinkable>
    {
        private readonly DiContainer _container;
        private readonly IPrefabsBase _prefabsBase;

        public SpawnService(DiContainer container, IPrefabsBase prefabsBase)
        {
            _container = container;
            _prefabsBase = prefabsBase;
        }

        public ILinkable Spawn(EcsEntity entity)
        {
            if (entity.Has<PrefabComponent>())
                return InstantiateLinkable(_prefabsBase.Get(entity.Get<PrefabComponent>().Value));
                
            throw new Exception($"[SpawnService] Can't instantiate entity with uid: " + entity);
        }

        private ILinkable InstantiateLinkable(GameObject prefab)
        {
            var go = _container.InstantiatePrefab(prefab, Vector3.zero, Quaternion.identity, null);
            var components = go.GetComponents<ILinkable>();
            Debug.Assert(components.Length == 1,$"Object view must have only one ILinkable component!!" +
                                                $" Description : {go.name} " );
            var linkable = go.GetComponent<ILinkable>();
            return linkable;
        }
    }
}