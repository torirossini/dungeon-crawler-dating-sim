using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public enum TimeOfDay
    {
        Morning=1,Midday=2,Evening=3,Night=4
    }
    public class TownManager : Singleton<TownManager>
    {

        public Player Player { get => player; set => player = value; }
        public CameraManager PlayerCamera { get => playerCamera; set => playerCamera = value; }
        public GameObject RightBridge { get => rightBridge; set => rightBridge = value; }
        public GameObject LeftBridge { get => leftBridge; set => leftBridge = value; }
        public Canvas ScreenCanvas { get => screenCanvas;}
        public int TimePoints { get => timePoints; set => timePoints = value; }

        [Header("Important Objects")]
        [SerializeField]
        Player player;

        [SerializeField]
        CameraManager playerCamera;

        [SerializeField]
        GameObject rightBridge;
        [SerializeField]
        GameObject leftBridge;

        [SerializeField]
        Canvas screenCanvas;

        [SerializeField]
        LightManager lightManager;

        [Header("Time Vars")]
        [SerializeField]
        const int MAX_TIME_POINTS = 5;
        [SerializeField]
        int timePoints;
        float timeIncrements;

        TimeOfDay currentTime;

        void Awake()
        {
            timePoints = 0;
            currentTime = TimeOfDay.Morning;
            timeIncrements = MAX_TIME_POINTS / Enum.GetNames(typeof(TimeOfDay)).Length;
        }

        public bool FacingRight(GameObject one, GameObject two)
        {
            if(Vector3.Distance(player.transform.position, one.transform.position) < Vector3.Distance(player.transform.position, two.transform.position))
            {
                return true;
                
            }
            return false;
        }

        public bool ExpendTimePoints(int numberToUse)
        {
            if(timePoints+numberToUse > MAX_TIME_POINTS)
            {
                Debug.Log("Cannot perform this action - Not enough time left!");
                return false;
            }
            timePoints += numberToUse;

            if (timePoints >= timeIncrements * (int)currentTime)
            {
                if (currentTime == TimeOfDay.Night)
                {
                    ChangeTimeOfDay(TimeOfDay.Morning);
                    timePoints = 0;
                }
                else
                {
                    ChangeTimeOfDay(currentTime + 1);
                }
                Debug.Log("Changing time to " + currentTime);
            }

            if (timePoints >= MAX_TIME_POINTS)
            {
                Debug.Log("Day ended. Resetting time points...");
                timePoints = 0;
            }
            return true;


        }

        public void ChangeTimeOfDay(TimeOfDay toTime)
        {
            currentTime = toTime;
        }
        void Update()
        {
            

        }


    }
}