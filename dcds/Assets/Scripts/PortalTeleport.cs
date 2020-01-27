using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PortalTeleport : MonoBehaviour
    {
        [SerializeField]
        GameObject targetPortal;
        [SerializeField]
        float zOffset = -2f;
        [SerializeField]
        float xOffset = 0f;
        [SerializeField]
        float yOffset = 0f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == TownManager.Instance.Player.gameObject)
            { 
                TownManager.Instance.Player.transform.position = new Vector3(targetPortal.transform.position.x + xOffset,
                    targetPortal.transform.position.y + yOffset,
                   targetPortal.transform.position.z + zOffset);
            }
        }
    }
}
