using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;


public class InventoryDisplay : MonoBehaviour
{
    // gameObject with an inventory to track
    public GameObject charToTrack;
    // generic inventory item prefab to instantiate and then modify with item values
    [SerializeField]
    GameObject inventoryItemPrefab;

    // when the parent panel is activated, grab a reference to the character's inventory and display its icon GameObject
    void OnEnable()
    {
        foreach (Item i in charToTrack.GetComponent<Inventory>().inventory)
        {
            if (i) // make sure an item is filling this slot
            {
                // create the prefab in the scene, then modify its contents based on the item in question
                GameObject itemInstance = Instantiate(inventoryItemPrefab, gameObject.transform);
                itemInstance.GetComponent<UseItemFromInventory>().trackedItem = i;
                itemInstance.GetComponent<Image>().sprite = i.Icon;
                // handle the title text contained within the prefab appropriately
                itemInstance.GetComponentInChildren<Text>().text = i.Name;
            }
        }
    }

    // when the parent panel is deactivated, delete the item representations
    void OnDisable()
    {
        // can't loop through a gameObject, so loop through its transform component instead
        Transform panelTransform = gameObject.transform;
        foreach (Transform child in panelTransform)
        {
            Destroy(child.gameObject);
        }
    }
}