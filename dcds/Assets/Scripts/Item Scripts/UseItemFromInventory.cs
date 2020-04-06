using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts;
using FMODUnity;

public class UseItemFromInventory : MonoBehaviour, IPointerClickHandler
{

    public Item trackedItem;

    // destroy the item in its inventory as well as its UI representation when clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponentInParent<InventoryDisplay>().charToTrack.GetComponent<Inventory>().RemoveItem(trackedItem);
        // play the item removal sound from the FMOD StudioEventEmitter component that should be attached to this GO
        GetComponent<StudioEventEmitter>().Play();
        Destroy(gameObject);
    }
}
