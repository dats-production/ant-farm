using System;
using UnityEngine;
using UnityEngine.AI;

namespace ECS.Views
{
    public interface ISelectable
    {
        void SetMouseDownAction(Action mouseDownAction);
    }
    public class SelectableView : LinkableView, ISelectable
    {
        private Action _mouseDownAction;

        public void SetMouseDownAction(Action mouseDownAction) => _mouseDownAction = mouseDownAction;
        private void OnMouseDown() => _mouseDownAction.Invoke();
    }
}