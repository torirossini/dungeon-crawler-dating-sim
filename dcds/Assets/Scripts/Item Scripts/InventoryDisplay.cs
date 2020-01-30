using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class InventoryDisplay : MonoBehaviour
    {
        // gameObject with an inventory to track
        public GameObject charToTrack;
        // placeholder gameObject used to help instantiate item pictures in the UI
        public GameObject itemImagePlaceholder;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        // when the parent panel is activated, grab a reference to the character's inventory and display it
        void OnEnable()
        {

            //foreach (Item i in charToTrack.GetComponent<Inventory>().inventory)
            //{

            //}
            for (int i = 0; i < 4; i++) // placeholder until I can grab info from items properly
            {
                Instantiate(itemImagePlaceholder, gameObject.transform);
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
