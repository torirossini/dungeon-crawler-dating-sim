using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// Contributors: Tori
namespace Assets
{
    class CanvasManager:Singleton<CanvasManager>
    {
        [SerializeField]
        TextMeshProUGUI timeDisplay;

        [SerializeField]
        GameObject interactIcons;

        public TextMeshProUGUI TimeDisplay { get => timeDisplay; set => timeDisplay = value; }
        public GameObject InteractIcons { get => interactIcons; set => interactIcons = value; }

        public void DestroyIcons()
        {
            foreach(Transform obj in InteractIcons.transform)
            {
                Destroy(obj);
            }
        }
    }
}
