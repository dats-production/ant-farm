using System;
using DataBase;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine.EventSystems;

namespace ECS.Views
{
    public interface ISelectable
    {
        void SetMouseDownAction(Action<Uid> mouseDownAction);
    }
    public class SelectableView : LinkableView, ISelectable, IPointerUpHandler, IPointerDownHandler
    {
        private Action<Uid> _mouseDownAction;

        public void SetMouseDownAction(Action<Uid> mouseDownAction)
        {
            _mouseDownAction = mouseDownAction;
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            _mouseDownAction?.Invoke(Entity.Get<UidComponent>().Value);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
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
    }
}