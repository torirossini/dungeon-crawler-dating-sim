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
        Light directionalLight1;

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
            directionalLight1.transform.rotation = morningLight;
            allowTransition = true;
        }
        void Start()
        {
           
        }

        void Update()
        {
            
        }

        private void UpdateLighting(int state)
        { 
        }

        IEnumerator LerpRotation(Light light1, Quaternion startRotation, Quaternion endRotation, float lerpTime)
        {
            float startTime = Time.time;
            float endTime = startTime + lerpTime;
            allowTransition = false;

            while (Time.time < endTime)
            {
                float timeProgressed = (Time.time - startTime) / lerpTime;  // this will be 0 at the beginning and 1 at the end.
                light1.transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeProgressed);
                yield return null;
            }
            allowTransition = true;
        }

    }
}
