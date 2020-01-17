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

        public TextMeshProUGUI TimeDisplay { get => timeDisplay; set => timeDisplay = value; }

    }
}
