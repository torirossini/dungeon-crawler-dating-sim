using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class InventoryDisplay : MonoBehaviour
    {
        // gameObject with an inventory to track
        public GameObject charToTrack;
        // generic inventory item prefab to instantiate and then modify with item values
        public GameObject inventoryItemPrefab;

        // when the parent panel is activated, grab a reference to the character's inventory and display its icon GameObject
        void OnEnable()
        {
            foreach (Item i in charToTrack.GetComponent<Inventory>().inventory)
            {
                if (i) // make sure an item is filling this slot
                {
                    // create the prefab in the scene, then modify its contents based on the item in question
                    GameObject itemInstance = Instantiate(inventoryItemPrefab, gameObject.transform);
                    itemInstance.GetComponent<Image>().sprite = i.Icon;
                    // handle the title and tooltip text contained within the prefab appropriately
                    Text[] textComponents = itemInstance.GetComponentsInChildren<Text>(true);
                    foreach (Text txt in textComponents)
                    {
                        Debug.Log(txt.name);
                        if (txt.name == "ItemTitle")
                            txt.text = i.Name;
                        if (txt.name == "ItemDescription")
                            txt.text = i.Description;
                        if (txt.name == "ItemSellPrice")
                            txt.text = i.SellPrice.ToString();
                    }
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
}
