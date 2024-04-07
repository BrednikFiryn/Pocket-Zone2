using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private InventorySlot[] _slots;
    public Inventory inventory;
    public Transform itemsParent;
    public GameObject inventoryUI;

    private void Start()
    {
        _slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void UpdateInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                _slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
