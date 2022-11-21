using System;
using ECS.Components.Flags;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Signals;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Gather 
{
    public class GatherViewController : UiController<GatherView>, IInitializable
    {
        [Inject] private readonly EcsWorld _world;
        private readonly SignalBus _signalBus;
        //private readonly float _animationTime = 1;
    
        public GatherViewController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            View.closeButton.OnClickAsObservable().Subscribe(Hide).AddTo(View);

            _signalBus.GetStream<SignalSelect>()
                .Subscribe(x => OnSelect(x.Entity, x.OnGather))
                .AddTo(View);
        }

        public override void OnShow()
        {
            View.name.text = "GATHER";
            // View.panel.DOAnchorPosX(-400, _animationTime)
            //     .SetEase(Ease.OutCubic);
        }
        
        private void OnSelect(EcsEntity selectedEntity, Action<EcsEntity> onGather)
        {
            View.gatherButton.OnClickAsObservable()
                .Subscribe(x=>onGather.Invoke(selectedEntity))
                .AddTo(View);
        }
        
        private void Hide(Unit _)
        {
            // View.panel.DOAnchorPosX(400, _animationTime)
            //     .SetEase(Ease.InCubic)
            //     .OnComplete(() => _signalBus.BackWindow());
            _signalBus.BackWindow();
        }
    }
}