using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    /// <summary>
    /// Singleton in charge of handling the town functionality and holds town references
    /// </summary>
    public class TownManager : Singleton<TownManager>
    {
        [SerializeField]
        GameObject rightBridge;
        [SerializeField]
        GameObject leftBridge;

        #region Getters/Setters       
        public GameObject RightBridge { get => rightBridge; set => rightBridge = value; }
        public GameObject LeftBridge { get => leftBridge; set => leftBridge = value; }

        #endregion

        public bool FacingRight(GameObject one, GameObject two)
        {
            if(Vector3.Distance(GameManager.Instance.Player.transform.position, one.transform.position) < Vector3.Distance(GameManager.Instance.Player.transform.position, two.transform.position))
            {
                return true;
                
            }
            return false;
        }


    }
}