using System;
using DataBase;

namespace ECS.Views
{
    public interface ISelectable
    {
        void SetMouseDownAction(Uid selectedUid, Action<Uid> mouseDownAction);
    }
    public class SelectableView : LinkableView, ISelectable
    {
        private Action<Uid> _mouseDownAction;
        private Uid _selectedUid;

        public void SetMouseDownAction(Uid selectedUid, Action<Uid> mouseDownAction)
        {
            _selectedUid = selectedUid;
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
            _mouseDownAction?.Invoke(_selectedUid);
        }
    }
}