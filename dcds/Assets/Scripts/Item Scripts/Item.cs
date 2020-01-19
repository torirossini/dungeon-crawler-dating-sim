using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// Contributors: Tori
namespace Assets.Scripts
{
    /// <summary>
    /// All item classes inherit from this class
    /// </summary>
    public abstract class Item
    {
        Image icon;
        string name;
        string description;
        int sellPrice;
        int purchasePrice;

        
    }
}
