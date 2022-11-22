using SimpleUi;

namespace UI.GameHud 
{
    public class GameHudWindow : WindowBase 
    {
        public override string Name => "GameHud";
        protected override void AddControllers()
        {
            AddController<GameHudViewController>();
        }
    }
}