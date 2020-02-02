using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class InventoryDisplay : MonoBehaviour
    {
        // gameObject with an inventory to track
        public GameObject charToTrack;

        // when the parent panel is activated, grab a reference to the character's inventory and display its icon GameObject
        void OnEnable()
        {
            foreach (Item i in charToTrack.GetComponent<Inventory>().inventory)
            {
                if(i) // make sure an item is filling this slot
                    Instantiate(i.Icon, gameObject.transform);
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
