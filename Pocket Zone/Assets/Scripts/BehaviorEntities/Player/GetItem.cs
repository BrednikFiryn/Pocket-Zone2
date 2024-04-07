using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            collision.GetComponent<PickUpItemAnim>().PickUp();
            collision.GetComponent<PickUpItem>().AddItemInventory();
        }
    }
}
