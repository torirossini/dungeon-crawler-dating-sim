using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// helper script for allowing an object to follow the mouse
public class FollowMouse : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }
}
