﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class LightManager:MonoBehaviour
    {
        [SerializeField]
        Light sunDirLight;

        float dayIncrements;
        [SerializeField]
        int currentState = 1;
        bool transitioning = false;
        bool startTransition = false;
        Vector3 targetRotation;
        Vector3 prevRotation;


        public float currentLerpTime;
        public float totalLerpTime;
        public float percentage;
        Vector3 newRot;

        public bool AllowTransition { get => transitioning; set => transitioning = value; }
        public float QuaternionThirdParameter = 0;

        void Awake()
        {
        }
        void Start()
        {
            currentLerpTime = 0.0f;
            percentage = 0.0f;
        }

        void Update()
        {
            if (transitioning)
            {
                currentLerpTime += Time.deltaTime;
                if (currentLerpTime > totalLerpTime)
                {
                    currentLerpTime = totalLerpTime;
                }

                percentage = currentLerpTime / totalLerpTime;
                if (percentage < 1)
                {
                    newRot = Vector3.Lerp(prevRotation, targetRotation, percentage);

                    sunDirLight.transform.rotation = Quaternion.Euler(newRot);

                }
                else
                {
                    sunDirLight.transform.rotation = Quaternion.Euler(targetRotation);
                    transitioning = false;
                }
            }
        }

        public void UpdateLighting(int state)
        {
            prevRotation = sunDirLight.transform.rotation.eulerAngles;
            SetupRotation(sunDirLight, 20f);
            if (state == 1)
            {
                targetRotation = new Vector3(20, 0, 0);
            }
            else if (state == 2)
            {
                targetRotation = new Vector3(90, 0, 0);
             
            }
            else if (state == 3)
            {
                targetRotation = new Vector3(138, 0, 0);
            }
            else if (state == 4)
            {
                targetRotation = new Vector3(0, 0, 0);
            }
            startTransition = true;
            transitioning = true;
        }

        void SetupRotation(Light sun, float time)
        {
            currentLerpTime = 0.0f;
            float AmountToTurn = Vector3.SignedAngle(prevRotation, targetRotation, Vector3.up);
            totalLerpTime = AmountToTurn / time;
            Debug.Log("Turning this many degrees: " + AmountToTurn + " starting with " + (currentLerpTime / totalLerpTime));
        }
    }
}
