using SimpleUi;

namespace UI.Warehouse 
{
    public class WarehouseWindow : WindowBase 
    {
        public override string Name => "Warehouse";
        protected override void AddControllers()
        {
            AddController<WarehouseViewController>();
        }
    }
}