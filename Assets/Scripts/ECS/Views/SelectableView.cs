using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace ECS.Views
{
    public interface ISelectable
    {
        void SetMouseDownAction(EcsEntity selectedEntity, Action<EcsEntity> mouseDownAction);
    }
    public class SelectableView : LinkableView, ISelectable
    {
        private Action<EcsEntity> _mouseDownAction;
        private EcsEntity _selectedEntity;

        public void SetMouseDownAction(EcsEntity selectedEntity, Action<EcsEntity> mouseDownAction)
        {
            _selectedEntity = selectedEntity;
            _mouseDownAction = mouseDownAction;
        }
        private void OnMouseDown() => _mouseDownAction.Invoke(_selectedEntity);
    }
}