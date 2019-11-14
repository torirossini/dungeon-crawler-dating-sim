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

        public bool FacingRight(GameObject one, GameObject two)
        {
            if(Vector3.Distance(player.transform.position, one.transform.position) < Vector3.Distance(player.transform.position, two.transform.position))
            {
                Debug.Log("One is closer");
                return true;
                
            }
            Debug.Log("Two is closer");
            return false;
        }


    }
}