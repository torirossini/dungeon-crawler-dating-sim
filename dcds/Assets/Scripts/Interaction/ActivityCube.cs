using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interaction
{
    class ActivityCube : InteractionObject
    { 
        public override void Interact()
        {
            TownManager.Instance.ExpendTimePoints(1);

            //VVVVV End all Interact methods with this VVVVVV
            StartCoroutine(TriggerInteract());
            ///^^^ This thing ^^^
        }
    }
}
