using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
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

        private Rigidbody rb;


        public float PlayerSpeed
        {
            get { return playerSpeed; }
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();    
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            moveZAxis = Input.GetAxis("Vertical") * playerZMultipler;
            moveXAxis = -Input.GetAxis("Horizontal") * playerXMultipler;
            PlayerMove();
        }

        //moveMethod
        public void PlayerMove()
        {
            Vector3 movement = new Vector3(moveZAxis, 0, moveXAxis) * playerSpeed;

            rb.MovePosition(transform.position + movement * Time.deltaTime);

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
                GameManager.Instance.PlayerCamera.ChangeView(Utility.CurrentView.Forward);
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
                //if (GameManager.Instance.TownManager.FacingRight(GameManager.Instance.TownManager.LeftBridge, GameManager.Instance.TownManager.RightBridge))
                //{
                //    GameManager.Instance.PlayerCamera.ChangeView(Utility.CurrentView.Left);
                //}
                //else
                //{
                //    GameManager.Instance.PlayerCamera.ChangeView(Utility.CurrentView.Right);

                //}
            }
        }

    }

}
