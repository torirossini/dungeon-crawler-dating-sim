using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class Player : MonoBehaviour
    {

        //variables
        [SerializeField]
        float playerSpeed = 0.15f;

        [SerializeField]
        float playerXMultipler = 1f;

        [SerializeField]
        float playerZMultipler = 1f;


        float moveZAxis;
        float moveXAxis;


        public float PlayerSpeed
        {
            get { return playerSpeed; }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            moveZAxis = Input.GetAxis("Vertical") * playerZMultipler;
            moveXAxis = -Input.GetAxis("Horizontal") * playerXMultipler;
            PlayerMove(playerSpeed);
        }

        //moveMethod
        public void PlayerMove(float speed)
        {
            Vector3 movement = new Vector3(moveZAxis, 0.0f, moveXAxis);

            gameObject.transform.position += movement * speed * Time.deltaTime;

        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<InteractionObject>())
            {
                InteractionObject interactable = other.gameObject.GetComponent<InteractionObject>();
                interactable.SetAblilityToInteract(true);
            }
            if(other.gameObject.CompareTag("Bridge"))
            {
                TownManager.Instance.PlayerCamera.ChangeView(Utility.CurrentView.Forward);
            }
            
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.gameObject.GetComponent<InteractionObject>())
            {
                InteractionObject interactable = other.gameObject.GetComponent<InteractionObject>();
                
                if (Input.GetKey(KeyCode.E) && !interactable.Interacted)
                {
                    interactable.Interact();
                    interactable.DoPulse();
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<InteractionObject>())
            {
                InteractionObject interactable = other.gameObject.GetComponent<InteractionObject>();
                interactable.SetAblilityToInteract(false);
            }
            if (other.gameObject.CompareTag("Bridge"))
            {
                if (TownManager.Instance.FacingRight(TownManager.Instance.LeftBridge, TownManager.Instance.RightBridge))
                {
                    TownManager.Instance.PlayerCamera.ChangeView(Utility.CurrentView.Left);
                }
                else
                {
                    TownManager.Instance.PlayerCamera.ChangeView(Utility.CurrentView.Right);

                }
            }
        }

    }

}
