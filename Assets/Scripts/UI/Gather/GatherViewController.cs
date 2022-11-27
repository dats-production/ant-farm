using System;
using DataBase;
using Leopotam.Ecs;
using Signals;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
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
                .Subscribe(x => OnSelect(x.SelectedUid, x.OnGather))
                .AddTo(View);
        }

        private void Test(PointerEventData eventData)
        {
            
        }

        public override void OnShow()
        {
            //Debug.Log($"SHOW {nameof(GatherViewController)}");
            View.name.text = "GATHER";
            // View.panel.DOAnchorPosX(-400, _animationTime)
            //     .SetEase(Ease.OutCubic);
        }
        
        private void OnSelect(Uid selectedUid, Action<Uid> onGather)
        {
            View.gatherButton.OnClickAsObservable()
                .Subscribe(x=>onGather.Invoke(selectedUid))
                .AddTo(View);
        }
        
        private void Hide(Unit _)
        {
            //Debug.Log($"HIDE {nameof(GatherViewController)}");
            // View.panel.DOAnchorPosX(400, _animationTime)
            //     .SetEase(Ease.InCubic)
            //     .OnComplete(() => _signalBus.BackWindow());
            _signalBus.BackWindow();
        }
    }
}