using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class TownManager : Singleton<TownManager>
    {

        public Player Player { get => player; set => player = value; }
        public PlayerFollowCamera PlayerCamera { get => playerCamera; set => playerCamera = value; }
        public float DistanceBetween { get => distanceBetween; set => distanceBetween = value; }

        [Header("Important Objects")]
        [SerializeField]
        Player player;

        [SerializeField]
        PlayerFollowCamera playerCamera;

        [SerializeField]
        GameObject[] bridgeColliders;

        float distanceBetween;
        float distanceFromNearest;

        void Start()
        {
            distanceBetween = Vector3.Distance(bridgeColliders[0].transform.position, bridgeColliders[1].transform.position);
        }

        void Update()
        {
            if(playerCamera.IsTransitioning)
            {
                GameObject closest = GetClosestObject(bridgeColliders);
            }
        }

        private GameObject GetClosestObject(GameObject[] objectTransforms)
        {
            GameObject tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;
            foreach (GameObject t in objectTransforms)
            {
                float dist = Vector3.Distance(t.transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }
            return tMin;
        }


    }
}