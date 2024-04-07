using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items;

    public void AddItem(Item itemToAdd)
    {
        foreach (InventoryItem invItem in items)
        {
            if (invItem.item.id == itemToAdd.id)
            {
                invItem.quantity++;
                return;
            }
        }

        InventoryItem newItem = new InventoryItem();
        newItem.item = itemToAdd;
        newItem.quantity = 1;
        items.Add(newItem);
    }
}
