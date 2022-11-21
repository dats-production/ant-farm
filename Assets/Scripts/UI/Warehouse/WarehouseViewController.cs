using Scripts.UI.Warehouse;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
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

        public void Initialize()
        {
            View.closeButton.OnClickAsObservable().Subscribe(Hide).AddTo(View);
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