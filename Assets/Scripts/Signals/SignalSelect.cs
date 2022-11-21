using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Signals
{
    public struct SignalSelect
    {
        public readonly Action<EcsEntity> OnGather;
        public EcsEntity Entity;

        public SignalSelect(EcsEntity entityToGather,
            Action<EcsEntity> onGather = null)
        {
            Entity = entityToGather;
            OnGather = onGather;
        }
    }
}