using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace UI.Warehouse 
{
    public class WarehouseViewController : UiController<WarehouseView>, IInitializable 
    {
        private readonly SignalBus _signalBus;
    
        public WarehouseViewController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public override void OnShow()
        {
            base.OnShow();
            //Debug.Log($"SHOW {nameof(WarehouseViewController)}");
        }

        public void Initialize()
        {
            View.closeButton.OnClickAsObservable().Subscribe(Hide).AddTo(View);
        }
        
        private void Hide(Unit _)
        {
            //Debug.Log($"HIDE {nameof(WarehouseViewController)}");
            // View.panel.DOAnchorPosX(400, _animationTime)
            //     .SetEase(Ease.InCubic)
            //     .OnComplete(() => _signalBus.BackWindow());
            _signalBus.BackWindow();
        }
    }
}