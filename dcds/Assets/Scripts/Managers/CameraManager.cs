using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Utility;

namespace Assets
{
    public class CameraManager:MonoBehaviour
    {
        [Header("Object References")]
        [SerializeField]
        GameObject playerObject;

        [Header("Z Axis Variables")]
        float cameraZoom = -30;

        [Header("X Axis Variables")]
        [SerializeField]
        float xPositionSmoothTime = .03f;
        float newPosX;
        Vector3 xAxisCameraPosition;


        [Header("Y Axis Variables")]
        [SerializeField]
        float yPositionSmoothTime = .05f;
        float newYPos;
        Vector3 yAxisCameraPosition;

        private void Start()
        {
            // reassign key vars here in case a scene switch has occurred
            playerObject = GameManager.Instance.Player.gameObject;
            GameManager.Instance.PlayerCamera = gameObject.GetComponent<CameraManager>();
            playerObject = GameManager.Instance.Player.gameObject;
        }

        private void FixedUpdate()
        {
            CalculateLerpXPosition();
            CalculateLerpYPosition();
            gameObject.transform.position = xAxisCameraPosition + yAxisCameraPosition;

        }

        public void CalculateLerpXPosition()
        {
            newPosX = Mathf.Lerp(gameObject.transform.position.x, playerObject.transform.position.x, xPositionSmoothTime);

            xAxisCameraPosition = new Vector3(newPosX, 0, cameraZoom);
        }

        public void CalculateLerpYPosition()
        {
            newYPos = Mathf.Lerp(gameObject.transform.position.y, playerObject.transform.position.y, yPositionSmoothTime);
            yAxisCameraPosition = new Vector3(0, newYPos, 0);
        }
    }
}
