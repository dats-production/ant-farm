using System;
using DataBase;
using Leopotam.Ecs;

namespace Signals
{
    public struct SignalSelect
    {
        public readonly Action<Uid> OnGather;
        public Uid SelectedUid;

        public SignalSelect(Uid selectedUid,
            Action<Uid> onGather = null)
        {
            SelectedUid = selectedUid;
            OnGather = onGather;
        }
    }
}