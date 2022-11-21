using System;
using UnityEngine;

namespace Signals
{
    public struct SignalGather
    {
        public readonly Action OnComplete;

        public SignalGather(Action onComplete = null)
        {
            OnComplete = onComplete;
        }
    }
}