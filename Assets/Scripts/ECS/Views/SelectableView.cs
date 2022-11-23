using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

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
        
        // private void Update()
        // {
        //     if(Input.GetMouseButtonDown(0))
        //     {
        //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //         RaycastHit hit;
        //         if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //         {
        //             Debug.Log(hit.transform.gameObject);
        //         }
        //     }
        // }

        private void OnMouseDown()
        {
            _mouseDownAction.Invoke(_selectedEntity);
        }
    }
}