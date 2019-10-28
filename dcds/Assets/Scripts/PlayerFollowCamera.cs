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

        public Vector3 rightCameraOffset;
        public Vector3 centerCameraOffset;
        public Vector3 leftCameraOffset;
        public Quaternion defaultCameraRotation;
        public Quaternion centerCameraRotation;

        private Vector3 currentPositionOffset;
        private Quaternion currentRotationOffset;


        float positionSmoothTime = .03f;
        float rotationSmoothTime = 1f;

        float newPosY, newPosZ, newPosX;
        Quaternion newRot;

        bool isTransitioning;

        [SerializeField]
        float timeToRotate = 2.0f;

        [SerializeField]
        float transitionTimeScalar = .2f;

        public bool IsTransitioning { get => isTransitioning; }
        public CurrentView CurrentlyFacing { get => currentlyFacing; set => currentlyFacing = value; }

        void Start()
        {
            isTransitioning = false;
            positionSmoothTime = playerObject.GetComponent<Player>().PlayerSpeed * Time.deltaTime;
            currentPositionOffset = rightCameraOffset;
            currentRotationOffset = defaultCameraRotation;

        }

        void FixedUpdate()
        {
            switch(currentlyFacing)
            {
                case CurrentView.Forward:
                    currentPositionOffset = centerCameraOffset;
                    currentRotationOffset = centerCameraRotation;
                    break;

                case CurrentView.Right:
                    currentPositionOffset = rightCameraOffset;
                    currentRotationOffset = defaultCameraRotation;
                    break;

                case CurrentView.Left:
                    currentPositionOffset = leftCameraOffset;
                    currentRotationOffset = defaultCameraRotation;
                    break;
            }

            newPosZ = Mathf.Lerp(gameObject.transform.position.z, playerObject.transform.position.z + currentPositionOffset.z, positionSmoothTime);
            newPosX = Mathf.Lerp(gameObject.transform.position.x, playerObject.transform.position.x + currentPositionOffset.x, positionSmoothTime);
            newPosY = Mathf.Lerp(gameObject.transform.position.y, playerObject.transform.position.y + currentPositionOffset.y, positionSmoothTime);

            gameObject.transform.position = new Vector3(newPosX, newPosY, newPosZ);

            Vector3 lookPos = playerObject.transform.position - gameObject.transform.position;
            lookPos.y = currentRotationOffset.y;
            newRot = Quaternion.LookRotation(lookPos);

            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotationSmoothTime);
           
        }

        public void ChangeView(CurrentView toView)
        {
            if (currentlyFacing != toView && !isTransitioning)
            {
                currentlyFacing = toView;
                StartCoroutine(Rotate(toView));
            }
        }

        IEnumerator Rotate(CurrentView toView)
        {
            isTransitioning = true;
            positionSmoothTime *= transitionTimeScalar;
            timeToRotate *= transitionTimeScalar;
            currentlyFacing = toView;
            yield return new WaitForSeconds(positionSmoothTime);
            isTransitioning = false;
            positionSmoothTime /= transitionTimeScalar;
            timeToRotate /= transitionTimeScalar;
        }
        
    }
}