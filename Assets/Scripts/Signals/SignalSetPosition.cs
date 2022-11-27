using System;
using DataBase;
using Leopotam.Ecs;
using UnityEngine;

namespace Signals
{
    public struct SignalSetPosition
    {
        public Vector3 Position;

        public SignalSetPosition(Vector3 position)
        {
            Position = position;
        }
    }
}