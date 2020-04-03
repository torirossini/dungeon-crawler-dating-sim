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
        float xOffset = 0f;
        [SerializeField]
        float yOffset = 0f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == GameManager.Instance.Player.gameObject)
            { 
                GameManager.Instance.Player.transform.position = new Vector2(targetPortal.transform.position.x + xOffset,
                    targetPortal.transform.position.y + yOffset);
            }
        }
    }
}
