using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Item
{
    Rigidbody itemObject;
    string interMessage;
    bool isActive;
    string name;

    public Item()
    {

    }

    // Constructor
    public Item(Rigidbody ItemObject, string interMessage)
    {
        ItemObject = itemObject;
        isActive = true;
        interMessage = "You have interacted with me!";
        itemObject.tag = "Interact";
    }

    // properties
    public bool IsActive
            {
                get{ return isActive; }
            }

        public Rigidbody ItemObject
        {
        get { return itemObject; }
        
        }
    }

