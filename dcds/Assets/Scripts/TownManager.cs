﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
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
        public int CurrentTimePoints { get => m_currentTimePoints; set => m_currentTimePoints = value; }
        public List<NPC> Npcs { get => npcs; set => npcs = value; }

        [Header("Important Objects")]
        [SerializeField]
        Player player;

        [SerializeField]
        CameraManager playerCamera;

        // List of NPCs to be managed
        [SerializeField]
        List<NPC> npcs;

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
        int m_currentTimePoints;
        float timeIncrements;

        TimeOfDay currentTime;

        void Awake()
        {
            m_currentTimePoints = 0;
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
            if(m_currentTimePoints+numberToUse > MAX_TIME_POINTS)
            {
                Debug.Log("Cannot perform this action - Not enough time left!");
                return false;
            }
            m_currentTimePoints += numberToUse;

            if (m_currentTimePoints >= timeIncrements * (int)currentTime)
            {
                if (currentTime == TimeOfDay.Night)
                {
                    ChangeTimeOfDay(TimeOfDay.Morning);
                    m_currentTimePoints = 0; 
                }
                else
                {
                    ChangeTimeOfDay(currentTime + 1);
                }
                Debug.Log("Changing time to " + currentTime);
            }

            if (m_currentTimePoints >= MAX_TIME_POINTS)
            {
                Debug.Log("Day ended. Resetting time points...");
                m_currentTimePoints = 0;
                // Reroll each npc's mood for the new day
                foreach(NPC npc in npcs)
                {
                    npc.MoodOfTheDay();
                }
            }
            return true;


        }

        public void ChangeTimeOfDay(TimeOfDay toTime)
        {
            currentTime = toTime;
            CanvasManager.Instance.TimeDisplay.SetText(toTime.ToString() + "\nTime Left: " + (MAX_TIME_POINTS - (int)toTime));
            lightManager.UpdateLighting((int)toTime);

        }
        void Update()
        {
            

        }


    }
}