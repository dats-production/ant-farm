using SimpleUi.Abstracts;
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
            View.testButton.OnClickAsObservable()
                .Subscribe(x => Debug.Log(222))
                .AddTo(View);
        }
    }
}