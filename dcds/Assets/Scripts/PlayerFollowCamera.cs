using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    public GameObject playerObject;
    public float cameraOffsetX = 5.0F;
    public float cameraOffsetY = 5.0f;
    public float cameraOffsetZ = -6.0F;

    float smoothTime = .03f;



    void Awake()
    {
        smoothTime = playerObject.GetComponent<PlayerMovement>().PlayerSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        float newPosZ = Mathf.Lerp(gameObject.transform.position.z, playerObject.transform.position.z + cameraOffsetZ, smoothTime);
        float newPosX = Mathf.Lerp(gameObject.transform.position.x, playerObject.transform.position.x + cameraOffsetX, smoothTime);

        gameObject.transform.position = new Vector3(newPosX,
            gameObject.transform.position.y,
            newPosZ);
    }
}
