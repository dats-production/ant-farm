using SimpleUi;

namespace UI.GatherWorld 
{
    public class GatherWorldWindow : WindowBase 
    {
        public override string Name => "GatherWorld";
        protected override void AddControllers()
        {
            AddController<GatherWorldViewController>();
        }
    }
}