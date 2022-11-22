using SimpleUi;

namespace UI.Gather 
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