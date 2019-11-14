using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class TownManager : Singleton<TownManager>
    {

        public Player Player { get => player; set => player = value; }
        public CameraManager PlayerCamera { get => playerCamera; set => playerCamera = value; }
        public GameObject RightBridge { get => rightBridge; set => rightBridge = value; }
        public GameObject LeftBridge { get => leftBridge; set => leftBridge = value; }

        [Header("Important Objects")]
        [SerializeField]
        Player player;

        [SerializeField]
        CameraManager playerCamera;

        [SerializeField]
        GameObject rightBridge;
        [SerializeField]
        GameObject leftBridge;

        public GameObject getCloserObject(GameObject one, GameObject two)
        {
            if(Vector3.Distance(gameObject.transform.position, one.transform.position) > Vector3.Distance(gameObject.transform.position, two.transform.position))
            {
                return two;
            }
            return one;
        }


    }
}