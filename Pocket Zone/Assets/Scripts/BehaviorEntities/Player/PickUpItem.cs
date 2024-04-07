using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Item item;

    public void AddItemInventory()
    {
        inventory.AddItem(item);
    }
}
