using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts;

public class InventoryTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // GO to instantiate as a tooltip
    public GameObject tooltipPrefab;
    // GO to track/destroy when needed
    GameObject tooltipInstance;

    // UI version of OnMouseEnter, use this to instantiate the prefab with the relevant data found in the parent
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        tooltipInstance = Instantiate(tooltipPrefab, GameObject.Find("Canvas").transform);

        // use the tracked item's info to fill out the tooltip text
        tooltipInstance.GetComponentInChildren<Text>().text += "Description: " + gameObject.GetComponent<UseItemFromInventory>().trackedItem.Description + "\n";
        tooltipInstance.GetComponentInChildren<Text>().text += "Sell Price: " + gameObject.GetComponent<UseItemFromInventory>().trackedItem.SellPrice.ToString();
    }

    // UI version of OnMousExit, use this destroy the prefab instance
    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(tooltipInstance);
    }
}
