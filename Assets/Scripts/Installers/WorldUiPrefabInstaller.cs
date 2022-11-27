using SimpleUi;
using UI.GameHud;
using UI.Gather;
using UI.GatherWorld;
using UI.Warehouse;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/WorldUiPrefabInstaller", fileName = "WorldUiPrefabInstaller")]
    public class WorldUiPrefabInstaller : ScriptableObjectInstaller
    {
        [FormerlySerializedAs("CanvasWorld"), SerializeField]
        private Canvas canvas;

        [SerializeField] private GatherWorldView gatherWorldView;

        public override void InstallBindings()
        {
            var canvasObj = Instantiate(canvas);
            canvasObj.renderMode = RenderMode.WorldSpace;
            canvasObj.worldCamera = Camera.main;
            var canvasTransform = canvasObj.transform;
            // var camera = canvasTransform.GetComponentInChildren<Camera>();
            // camera.clearFlags = CameraClearFlags.Depth;
            // camera.orthographic = false;
            // camera.transform.SetParent(null);
            // camera.transform.position = .transform.position;
            // camera.transform.rotation = Camera.main.transform.rotation;

            Container.Bind<Canvas>().FromInstance(canvasObj).NonLazy();
            //Container.Bind<Camera>().FromInstance(camera).AsSingle().WithConcreteId(0).NonLazy();

            
            Container.BindUiView<GatherWorldViewController, GatherWorldView>(gatherWorldView, canvasTransform);
        }
    }
}