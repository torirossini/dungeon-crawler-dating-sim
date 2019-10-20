using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class PlayerFollowCamera : MonoBehaviour
    {
        public GameObject playerObject;
        public float cameraOffsetX = 5.0F;
        public float cameraOffsetY = 5.0f;
        public float cameraOffsetZ = -6.0F;

        float smoothTime = .03f;

        float newPosY, newPosZ, newPosX;



        void Start()
        {
            smoothTime = playerObject.GetComponent<Player>().PlayerSpeed * Time.deltaTime;

        }

        void FixedUpdate()
        {
            newPosZ = Mathf.Lerp(gameObject.transform.position.z, playerObject.transform.position.z + cameraOffsetZ, smoothTime);
            newPosX = Mathf.Lerp(gameObject.transform.position.x, playerObject.transform.position.x + cameraOffsetX, smoothTime);
            newPosY = Mathf.Lerp(gameObject.transform.position.y, playerObject.transform.position.y + cameraOffsetY, smoothTime);

            gameObject.transform.position = new Vector3(newPosX, newPosY, newPosZ);
        }
    }
}