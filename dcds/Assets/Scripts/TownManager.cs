﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class TownManager : Singleton<TownManager>
    {

        public GameObject Player { get => player; set => player = value; }
        public GameObject PlayerCamera { get => playerCamera; set => playerCamera = value; }

        [Header("Important Objects")]
        [SerializeField]
        GameObject player;

        [SerializeField]
        GameObject playerCamera;


        [Header("1st to 2nd Floor Portals")]
        [SerializeField]
        GameObject firstFloorPortal;

        [SerializeField]
        GameObject secondFloorPortal;



    }
}