using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    class CanvasManager:Singleton<CanvasManager>
    {
        [SerializeField]
        TextMeshProUGUI timeDisplay;
        
        [SerializeField]
        InventoryDisplay inventoryDisplay;

        [SerializeField]
        private GameObject interactionIcons;


        public TextMeshProUGUI TimeDisplay { get => timeDisplay; set => timeDisplay = value; }
        public InventoryDisplay InventoryDisplay { get => inventoryDisplay; set => inventoryDisplay = value; }
        public GameObject InteractionIcons { get => interactionIcons; set => interactionIcons = value; }

        private void Start()
        {
            inventoryDisplay.charToTrack = GameManager.Instance.PlayerReference.gameObject;
        }

        public void DestroyIcons()
        {
            foreach (Transform child in interactionIcons.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
