using Signals;
using SimpleUi.Abstracts;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.GatherWorld 
{
    public class GatherWorldViewController : UiController<GatherWorldView>, IInitializable 
    {
        private readonly SignalBus _signalBus;
    
        public GatherWorldViewController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.GetStream<SignalSetPosition>()
                .Subscribe((x) => SetPosition(x.Position))
                .AddTo(View);
        }

        private void SetPosition(Vector3 position)
        {
            Debug.Log(position);
            View.transform.position = position;
            View.transform.LookAt(Camera.main.transform);
        }
        
        
        // from SelectSystem
        //var ownerPos = _world.GetOwnerEntity(selectedEntity).Get<PositionComponent>().Value;
        //_signalBus.Fire(new SignalSetPosition(ownerPos));
    }
}