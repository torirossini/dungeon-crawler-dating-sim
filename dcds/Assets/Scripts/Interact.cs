using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class Interact : MonoBehaviour
    {

        SphereCollider interactRadius;
        bool inRange = false;
        bool interacted = false;

        void Awake()
        {
            interactRadius = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
            interactRadius.radius = 2.5f;
            interactRadius.isTrigger = true;

        }


        public void SetAblilityToInteract(bool able)
        {
            if (able)
            {
                Debug.Log("You can interact with me");
                inRange = able;
            }
            else
            {
                Debug.Log("You can no longer interact with me");
                inRange = false;
                interacted = false;
            }
        }

        public bool TriggerInteract()
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!interacted)
                {
                    Debug.Log("You have interacted with me.");
                    interacted = true;
                    return true;
                }
            }
            else if (interacted)
            {
                interacted = false;
            }
            return false;
        }

    }
}

