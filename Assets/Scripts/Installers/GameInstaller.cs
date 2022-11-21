using ECS.Utils.Impls;
using Initializers;
using Scripts.UI.GameHud;
using Scripts.UI.Gather;
using Scripts.UI.Warehouse;
using Services.PauseService.Impls;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            BindServices();
            BindWindows();
            Container.BindInterfacesAndSelfTo<GameInitializer>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<GameHudWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<GatherWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<WarehouseWindow>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<SpawnService>().AsSingle();
            Container.BindInterfacesTo<PauseService>().AsSingle();
        }
    }
}