using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class NPCInteraction : InteractionObject
    {
        NPC thisNPC;

        private void Awake()
        {
            thisNPC = gameObject.GetComponent<NPC>();
            thisNPC.flowchart.enabled = false;
        }

        public override void Interact()
        {
            thisNPC.flowchart.enabled = true;

            //VVVVV End all Interact methods with this VVVVVV
            StartCoroutine(TriggerInteract());
            ///^^^ This thing ^^^
        }
    }
}
