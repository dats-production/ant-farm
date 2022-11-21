using SimpleUi;
using UI.Warehouse;

namespace Scripts.UI.Warehouse 
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