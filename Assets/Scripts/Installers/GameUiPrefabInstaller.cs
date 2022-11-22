using SimpleUi;
using UI.GameHud;
using UI.Gather;
using UI.Warehouse;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/GameUiPrefabInstaller", fileName = "GameUiPrefabInstaller")]
    public class GameUiPrefabInstaller : ScriptableObjectInstaller
    {
        [FormerlySerializedAs("Canvas"), SerializeField]
        private Canvas canvas;

        [SerializeField] private GameHudView inGameMenu;
        [SerializeField] private GatherView gatherView;
        [SerializeField] private WarehouseView warehouseView;

        public override void InstallBindings()
        {
            var canvasObj = Instantiate(canvas);
            var canvasTransform = canvasObj.transform;
            var camera = canvasTransform.GetComponentInChildren<Camera>();
            camera.clearFlags = CameraClearFlags.Depth;
            camera.orthographic = false;
            camera.transform.SetParent(null);

            Container.Bind<Canvas>().FromInstance(canvasObj).AsSingle().NonLazy();
            Container.Bind<Camera>().FromInstance(camera).AsSingle().WithConcreteId(0).NonLazy();

            Container.BindUiView<GameHudViewController, GameHudView>(inGameMenu, canvasTransform);
            Container.BindUiView<GatherViewController, GatherView>(gatherView, canvasTransform);
            Container.BindUiView<WarehouseViewController, WarehouseView>(warehouseView, canvasTransform);
        }
    }
}