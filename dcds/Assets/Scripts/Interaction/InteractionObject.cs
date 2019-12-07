using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public abstract class InteractionObject : MonoBehaviour
    {

        SphereCollider interactRadius;
        bool inRange = false;
        bool interacted = false;

        [SerializeField]
        Image interactIcon;
        Image interactIconObject;

        [Header("UI Position Variables")]
        [SerializeField]
        float bobSpeed = 3.0f;
        [SerializeField]
        float bobAmplitude = 6f;

        [SerializeField]
        Vector3 offset = new Vector3(0, 100, 0);

        void Awake()
        {
            interactRadius = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
            interactRadius.radius = 2.5f;
            interactRadius.isTrigger = true;
            interactIconObject = GameObject.Instantiate(interactIcon, TownManager.Instance.ScreenCanvas.transform);
            interactIconObject.gameObject.SetActive(false);
        }


        public void SetAblilityToInteract(bool able)
        {
            if (able)
            {
                Debug.Log("You can interact with me");
                inRange = able;
                interactIconObject.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("You can no longer interact with me");
                inRange = false;
                interacted = false;
                interactIconObject.gameObject.SetActive(false);
            }
        }

        protected bool TriggerInteract()
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!interacted)
                {
                    Debug.Log("You have interacted with me.");
                    interacted = true;
                    DoPulse();
                    return true;

                }
            }
            else if (interacted)
            {
                interacted = false;
            }
            return false;
        }

        void Update()
        {
            if (inRange)
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                float newY = Mathf.Sin(Time.time * bobSpeed);
                pos = new Vector3(pos.x + offset.x, pos.y + (newY * bobAmplitude) + offset.y, pos.z + offset.z);
                interactIconObject.transform.position = pos;
            }
        }

        public void DoPulse()
        {
            System.Collections.Hashtable hash =
                      new System.Collections.Hashtable();
            hash.Add("amount", new Vector3(1f, 1f, 0f));
            hash.Add("time", 1f);
            iTween.PunchScale(interactIconObject.gameObject, hash);
        }

        public abstract void Interact();

    }
}

