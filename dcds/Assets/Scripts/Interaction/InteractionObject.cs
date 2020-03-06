using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public abstract class InteractionObject : MonoBehaviour
    {
        [SerializeField]
        float m_interactRadius = 2.5f;
        SphereCollider m_interactRadiusCollider;
        bool m_inRange = false;
        private bool interacted = false;

        [SerializeField]
        Image interactIcon;
        GameObject interactIconObject;

        [Header("UI Position Variables")]
        [SerializeField]
        float bobSpeed = 3.0f;
        [SerializeField]
        float bobAmplitude = 6f;

        [SerializeField]
        Vector3 offset = new Vector3(0, 100, 0);

        public bool Interacted { get => interacted; set => interacted = value; }

        protected virtual void Awake()
        {
            m_interactRadiusCollider = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
            m_interactRadiusCollider.radius = m_interactRadius;
            m_interactRadiusCollider.isTrigger = true;
            interactIconObject = GameObject.Instantiate(interactIcon, CanvasManager.Instance.InteractIcons.transform).gameObject;
            interactIconObject.SetActive(false);
        }


        public void SetAblilityToInteract(bool able)
        {
            if (able)
            {
                m_inRange = able;
                interactIconObject.SetActive(true);
            }
            else
            {
                m_inRange = false;
                interacted = false;
                interactIconObject.SetActive(false);
            }
        }

        protected IEnumerator TriggerInteract()
        {
            interacted = true;
            DoPulse();
            yield return new WaitForSeconds(1);
            interacted = false;
        }

        protected virtual void Update()
        {
            //Check that the icon isn't null before accessing it
            if (interactIconObject)
            {
                if (m_inRange)
                {
                    Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                    float newY = Mathf.Sin(Time.time * bobSpeed);
                    pos = new Vector3(pos.x + offset.x, pos.y + (newY * bobAmplitude) + offset.y, pos.z + offset.z);
                    interactIconObject.transform.position = pos;
                }
            }
        }

        public void DoPulse()
        {
            System.Collections.Hashtable hash =
                      new System.Collections.Hashtable();
            hash.Add("amount", new Vector3(1f, 1f, 0f));
            hash.Add("time", 1f);
            iTween.PunchScale(interactIconObject, hash);
        }

        public abstract void Interact();

    }
}

