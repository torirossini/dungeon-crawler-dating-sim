using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GiveItemCube:InteractionObject
{
    [SerializeField]
    Item toAdd;

    public override void Interact()
    {
        GameManager.Instance.PlayerInventory.AddItem(toAdd);

        //VVVVV End all Interact methods with this VVVVVV
        StartCoroutine(TriggerInteract());
        ///^^^ This thing ^^^
    }
}

