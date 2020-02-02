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
    public abstract class Item : MonoBehaviour
    {
        [SerializeField]
        GameObject icon; // store as GO so it can be rendered in UI as its own object
        [SerializeField]
        string name;
        [SerializeField]
        string description;
        [SerializeField]
        int sellPrice;
        [SerializeField]
        int purchasePrice;

        // getters for these variables
        public GameObject Icon { get => icon; }
        public string Name { get => name; }
        public string Description { get => description; }
        public int SellPrice { get => sellPrice; }
        public int PurchasePrice { get => purchasePrice; }

    }
}
