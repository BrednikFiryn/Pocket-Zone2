using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private InventoryItem _inventoryItem;
    public Image icon;
    public Text countText;

    public void AddItem(InventoryItem newItem)
    {
        _inventoryItem = newItem;
        icon.sprite = _inventoryItem.item.icon;
        icon.enabled = true;
        countText.text = _inventoryItem.quantity > 1 ? _inventoryItem.quantity.ToString() : "";
    }

    public void ClearSlot()
    {
        _inventoryItem.quantity--;

        if (_inventoryItem.quantity == 0)
        {
            _inventoryItem.item = null;
            icon.sprite = null;
            icon.enabled = false;
            countText.text = "";
        }
    }
}
