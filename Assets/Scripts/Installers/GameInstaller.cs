using ECS.DataSave;
using ECS.Utils.Impls;
using Game.Utils.MonoBehUtils;
using Services.PauseService.Impls;
using UnityEditor;
using UnityEngine;
using Zenject;
using ZenjectUtil.Test.Extensions;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GetPointFromScene getPointFromScene;
        //[SerializeField] private PlayerInputModule playerInputModule;
        //[SerializeField] private PrefabsBase prefabBase;
        
        public override void InstallBindings()
        {
            BindServices();
        }

        private void BindModules()
        {
            Container.Bind<GetPointFromScene>().FromInstance(getPointFromScene).AsSingle();
        }
        
        
        private void BindServices()
        {
            Container.BindInterfacesTo<SpawnService>().AsSingle();
            Container.BindInterfacesTo<PauseService>().AsSingle();
        }
    }
}