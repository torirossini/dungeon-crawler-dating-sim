﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

namespace Assets.Scripts.Interaction
{
    class Door : InteractionObject
    {
        [Header("Door Variables")]
        [SerializeField]
        GameObject targetObject;
        [SerializeField]
        Vector2 mapLoc;
        [SerializeField]
        bool CanEnter;


        public override void Interact()
        {
            // play the door open sound from the FMOD StudioEventEmitter component that should be attached to this GO
            GetComponent<StudioEventEmitter>().Play();
            if (CanEnter)
            {
                if (targetObject)
                {
                    Player.Instance.TeleportTo(targetObject);
                }
                else
                {
                    Player.Instance.TeleportTo(mapLoc);
                }
            }
            else
            {

            }

        }
    }
}
