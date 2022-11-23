using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace ECS.Views
{
    public abstract class GatherView : SelectableView
    {
        public Transform menu;
        public Button gatherButton;

        public override void Link(EcsEntity entity)
        {
            base.Link(entity);
            menu.LookAt(Camera.main.transform);
        }
    }
}