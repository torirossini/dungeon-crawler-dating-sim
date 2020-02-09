using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        foreach (Text txt in gameObject.GetComponentsInChildren<Text>(true))
        {
            if (txt.name == "ItemDescription")
                tooltipInstance.GetComponentInChildren<Text>().text += "Description: " + txt.text + "\n";
            if (txt.name == "ItemSellPrice")
                tooltipInstance.GetComponentInChildren<Text>().text += "Sell Price: " + txt.text;
        }
    }

    // UI version of OnMousExit, use this destroy the prefab instance
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Despawning");
        Destroy(tooltipInstance);
    }
}
