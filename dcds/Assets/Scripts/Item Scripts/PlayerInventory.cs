using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    // very basic inventory backend that allows items to be added/removed from a list
    public class PlayerInventory : MonoBehaviour
    {
        public int inventorySize = 4;
        public List<Item> inventory;

        public void AddItem(Item itemToAdd)
        {
            if (inventory.Count < inventorySize)
                inventory.Add(itemToAdd);
            else
                Debug.Log("Inventory is full, can't add this item!");
        }
        public void RemoveItem(Item itemToRemove)
        {
            inventory.Remove(itemToRemove);
        }
    }
}
