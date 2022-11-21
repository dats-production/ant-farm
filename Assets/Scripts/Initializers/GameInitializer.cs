﻿using Leopotam.Ecs;
using Scripts.UI.GameHud;
using SimpleUi.Signals;
using Zenject;

namespace Initializers
{
    public class GameInitializer : IInitializable
    {
        private readonly SignalBus _signalBus;
        private readonly EcsWorld _world;

        public GameInitializer(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.OpenWindow<GameHudWindow>();
        }
    }
}