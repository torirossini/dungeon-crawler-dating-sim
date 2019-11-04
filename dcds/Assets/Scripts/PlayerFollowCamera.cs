using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

namespace Assets
{
    public class PlayerFollowCamera : MonoBehaviour
    {
        [SerializeField]
        GameObject playerObject;

        [SerializeField]
        CurrentView currentlyFacing;

        Camera currentCamera;

        public Vector3 rightCameraOffset;
        public Vector3 centerCameraOffset;
        public Vector3 leftCameraOffset;
        public Quaternion defaultCameraRotation;
        public Quaternion centerCameraRotation;

        private Vector3 currentPositionOffset;
        private Quaternion currentRotationOffset;

        private Vector3 targetPositionOffset;
        private Quaternion targetRotationOffset;

        private bool isTransitioning;

        float positionSmoothTime = .03f;

        float newPosY, newPosZ, newPosX;

        public CurrentView CurrentlyFacing { get => currentlyFacing; set => currentlyFacing = value; }
        public bool IsTransitioning { get => isTransitioning; set => isTransitioning = value; }

        void Start()
        {
            positionSmoothTime = playerObject.GetComponent<Player>().PlayerSpeed * Time.deltaTime;
            currentPositionOffset = rightCameraOffset;
            currentRotationOffset = defaultCameraRotation;
            targetPositionOffset = rightCameraOffset;
            targetRotationOffset = defaultCameraRotation;
            currentCamera = gameObject.GetComponent<Camera>();


        }

        void FixedUpdate()
        {
            switch(currentlyFacing)
            {
                case CurrentView.Forward:
                    targetPositionOffset = centerCameraOffset;
                    targetRotationOffset = centerCameraRotation;
                    break;

                case CurrentView.Right:
                    targetPositionOffset = rightCameraOffset;
                    targetRotationOffset = defaultCameraRotation;
                    break;

                case CurrentView.Left:
                    targetPositionOffset = leftCameraOffset;
                    targetRotationOffset = defaultCameraRotation;
                    break;
            }

            newPosZ = Mathf.Lerp(gameObject.transform.position.z, playerObject.transform.position.z + currentPositionOffset.z, positionSmoothTime);
            newPosX = Mathf.Lerp(gameObject.transform.position.x, playerObject.transform.position.x + currentPositionOffset.x, positionSmoothTime);

            gameObject.transform.position = new Vector3(newPosX, newPosY, newPosZ);
            gameObject.transform.LookAt(playerObject.transform);
            
           
        }
        
    }
}