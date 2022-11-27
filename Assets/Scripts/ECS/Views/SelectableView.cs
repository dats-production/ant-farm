using System;
using DataBase;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ECS.Views
{
    public interface ISelectable
    {
        void SetMouseDownAction(Action<Uid> mouseDownAction);
    }
    public class SelectableView : LinkableView, ISelectable, IPointerUpHandler
    {
        private Action<Uid> _mouseDownAction;

        public void SetMouseDownAction(Action<Uid> mouseDownAction)
        {
            _mouseDownAction = mouseDownAction;
        }
        
        protected virtual void OnMouseDown()
        {
            //_mouseDownAction?.Invoke(Entity.Get<UidComponent>().Value);
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
        public void OnPointerUp(PointerEventData eventData)
        {
            _mouseDownAction?.Invoke(Entity.Get<UidComponent>().Value);
        }
    }
}