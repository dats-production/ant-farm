using SimpleUi;
using UI.Gather;

namespace Scripts.UI.Gather 
{
    public class GatherWindow : WindowBase 
    {
        public override string Name => "Gather";
        protected override void AddControllers()
        {
            AddController<GatherViewController>();
        }
    }
}