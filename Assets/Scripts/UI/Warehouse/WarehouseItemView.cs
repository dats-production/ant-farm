using TMPro;
using UnityEngine;

namespace UI.Warehouse
{
    public class WarehouseItemView : MonoBehaviour
    {
        [SerializeField] private TMP_Text name;
        [SerializeField] private TMP_Text count;

        public void Initialize(string name, int count)
        {
            this.name.text = name;
            this.count.text = count.ToString();
        }
    }
}