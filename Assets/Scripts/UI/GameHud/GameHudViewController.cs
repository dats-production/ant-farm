using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.GameHud 
{
    public class GameHudViewController : UiController<GameHudView> , IInitializable
    {
        private readonly SignalBus _signalBus;
    
        public GameHudViewController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            View.closeButton.OnClickAsObservable()
                .Subscribe(x => _signalBus.BackWindow())
                .AddTo(View);
        }
    }
}