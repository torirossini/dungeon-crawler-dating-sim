using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Utility;

namespace Assets.Scripts.Interaction
{
    class Door : InteractionObject
    {
        [Header("Door Variables")]
        [SerializeField]
        Locations locationToGo;
        public override void Interact()
        {
            GameManager.Instance.SceneSwitcher.Transition(locationToGo);

            //VVVVV End all Interact methods with this VVVVVV
            StartCoroutine(TriggerInteract());
            ///^^^ This thing ^^^
            ///
        }
    }
}
