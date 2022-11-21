using System.Collections.Generic;
using SimpleUi.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Warehouse 
{
    public class WarehouseView : UiView 
    {
        public Button closeButton;
        public TMP_Text name;
        public Transform itemsContainer;
        public WarehouseItemView item;
        private List<WarehouseItemView> _items;
        
        public void SetItems(List<WarehouseItemView> itemsInStorage)
        {
            var difference = itemsInStorage.Count - _items.Count;
            if (difference > 0)
            {
                for (var i = 0; i < difference; i++)
                {
                    AddItem();
                }
            }

            for (var i = 0; i < itemsInStorage.Count; i++)
            {
                var item = itemsInStorage[i];
                //_items[i].Initialize(item.name, item.count);
            }
        }

        private void AddItem()
        {
            var itemView = Instantiate(item, itemsContainer);
            _items.Add(itemView);
        }
    }
}