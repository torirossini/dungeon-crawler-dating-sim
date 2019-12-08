using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class LightManager:MonoBehaviour
    {
        [SerializeField]
        Light sunDirLight;

        float dayIncrements;
        [SerializeField]
        int currentState = 1;
        bool allowTransition;

        [Header("Morning Lighting")]
        [SerializeField]
        Quaternion morningLight;

        [SerializeField]
        float transitionTimeMorning = 3f;

        [Header("Midday Lighting")]
        [SerializeField]
        Quaternion middayLight;

        [SerializeField]
        float transitionTimeMidday = 3f;

        [Header("Evening Lighting")]
        [SerializeField]
        Quaternion eveningLight;

        [SerializeField]
        float transitionTimeEvening = 3f;

        [Header("Night Lighting")]
        [SerializeField]
        Quaternion nightLight;

        [SerializeField]
        float transitionTimeNight = 3f;



        void Awake()
        {
            sunDirLight.transform.rotation = morningLight;
            allowTransition = true;
        }
        void Start()
        {
           
        }

        void Update()
        {
            
        }

        public void UpdateLighting(int state)
        {
            if (allowTransition)
            {
                if (state == 1)
                {
                    StartCoroutine(LerpRotation(sunDirLight, morningLight, middayLight, transitionTimeMidday));
                }
                else if (state == 2)
                {
                    StartCoroutine(LerpRotation(sunDirLight, middayLight, eveningLight, transitionTimeEvening));

                }
                else if (state == 3)
                {
                    StartCoroutine(LerpRotation(sunDirLight, eveningLight, nightLight, transitionTimeNight));

                }
                else if (state == 4)
                {
                    StartCoroutine(LerpRotation(sunDirLight, nightLight, morningLight, transitionTimeMorning));

                }
            }
        }

        // TODO THIS IS BROKE
        IEnumerator LerpRotation(Light light, Quaternion startRotation, Quaternion endRotation, float lerpTime)
        {

            Quaternion startingRotation = light.transform.rotation; // have a startingRotation as well
            Quaternion targetRotation = endRotation;
            allowTransition = false;
            float percent = 0;
            while (percent < lerpTime)
            {
                percent += Time.deltaTime; // <- move elapsedTime increment here
                // Rotations
                transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, (percent / lerpTime));
                yield return new WaitForEndOfFrame();
            }

            allowTransition = true;
        }

    }
}
