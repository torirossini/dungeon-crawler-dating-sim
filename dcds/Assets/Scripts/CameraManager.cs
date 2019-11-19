using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Utility;

namespace Assets
{
    public class CameraManager:MonoBehaviour
    {
        [Header("Object References")]
        [SerializeField]
        GameObject playerObject;
        [SerializeField]
        GameObject dungeonEntrance;
        Camera cameraScriptReference;

        [Header("Camera Offsets")]
        public Vector3 rightCameraOffset;
        public Vector3 centerCameraOffset;
        public Vector3 leftCameraOffset;

        private Vector3 currentPositionOffset;

        [Header("XZ Axis Variables")]
        [SerializeField]
        float xzPositionSmoothTime = .03f;
        float newPosZ, newPosX;
        Vector3 xzAxisCameraPosition;


        [Header("Y Axis Variables")]
        [SerializeField]
        float yPositionSmoothTime = .05f;
        float newYPos;
        Vector3 yAxisCameraPosition;

        [Header("Rotation Variables")]
        Quaternion currentCameraRot;
        [SerializeField]
        float cameraRotationSmoothTime = .5f;

        [Header("Transition Variables")]
        bool isTransitioning;
        GameObject cameraFocus;
        float xzTransitionSmoothTime = .03f;

        private void Start()
        {
            isTransitioning = false;
            currentPositionOffset = rightCameraOffset;
            cameraScriptReference = gameObject.GetComponent<Camera>();
            StartCoroutine(ChangeCameraFocusTo(playerObject));
            
        }

        private void FixedUpdate()
        {
            CalculateLerpZXPosition();
            CalculateLerpYPosition();
            CalculateCameraRotation();
            gameObject.transform.position = xzAxisCameraPosition + yAxisCameraPosition;
            gameObject.transform.rotation = currentCameraRot;

        }

        public void CalculateLerpZXPosition()
        {
            if (isTransitioning)
            {
                newPosZ = Mathf.Lerp(gameObject.transform.position.z, playerObject.transform.position.z + currentPositionOffset.z, xzTransitionSmoothTime);
                newPosX = Mathf.Lerp(gameObject.transform.position.x, playerObject.transform.position.x + currentPositionOffset.x, xzTransitionSmoothTime);
            }
            else
            {
                newPosZ = Mathf.Lerp(gameObject.transform.position.z, playerObject.transform.position.z + currentPositionOffset.z, xzPositionSmoothTime);
                newPosX = Mathf.Lerp(gameObject.transform.position.x, playerObject.transform.position.x + currentPositionOffset.x, xzPositionSmoothTime);
            }
            xzAxisCameraPosition = new Vector3(newPosX, 0, newPosZ);
        }

        public void CalculateLerpYPosition()
        {
            newYPos = Mathf.Lerp(gameObject.transform.position.y, playerObject.transform.position.y + currentPositionOffset.y, yPositionSmoothTime);
            yAxisCameraPosition = new Vector3(0, newYPos, 0);
        }

        public void CalculateCameraRotation()
        {
            currentCameraRot = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(cameraFocus.transform.position-gameObject.transform.position), cameraRotationSmoothTime);
        }

        public IEnumerator ChangeCameraFocusTo(GameObject obj)
        {
            cameraFocus = obj;
            isTransitioning = true;
            yield return new WaitForSeconds(xzTransitionSmoothTime);
            isTransitioning = false;
            
        }

        public void ChangeView(CurrentView toView)
        {
            switch(toView)
            {
                case CurrentView.Forward:
                    currentPositionOffset = centerCameraOffset;
                    StartCoroutine(ChangeCameraFocusTo(dungeonEntrance));
                    break;
                case CurrentView.Right:
                    currentPositionOffset = rightCameraOffset;
                    StartCoroutine(ChangeCameraFocusTo(playerObject));
                    break;
                case CurrentView.Left:
                    currentPositionOffset = leftCameraOffset;
                    StartCoroutine(ChangeCameraFocusTo(playerObject));
                    break;
            }

        }
    }
}
