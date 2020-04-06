using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


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
        private Vector3 velocityVector;

        private Animator animator;
        private Sprite playerSprite;



        public float PlayerSpeed
        {
            get { return playerSpeed; }
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            playerSprite = GetComponent<SpriteRenderer>().sprite;
            velocityVector = Vector3.zero;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            moveZAxis = Input.GetAxis("Horizontal") * playerZMultipler;
            moveXAxis = Input.GetAxis("Vertical") * playerXMultipler;

            if(Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
            
            PlayerMove();
            IsWalking();

        }

        //moveMethod
        public void PlayerMove()
        {
            velocityVector = new Vector3(moveZAxis, 0, moveXAxis) * playerSpeed;

            rb.MovePosition(transform.position + velocityVector * Time.deltaTime);
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
            // if inside a recognized walking area while walking, set the FMOD walking noises appropriately
            if (IsWalking())
            {
                if(other.gameObject.CompareTag("DirtZone"))
                    GetComponent<StudioEventEmitter>().EventInstance.setParameterByName("DirtWalk", 1.0f);
                if (other.gameObject.CompareTag("GravelZone"))
                    GetComponent<StudioEventEmitter>().EventInstance.setParameterByName("GravelWalk", 1.0f);
                if (other.gameObject.CompareTag("WoodZone"))
                    GetComponent<StudioEventEmitter>().EventInstance.setParameterByName("WoodZone", 1.0f);
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

        private bool IsWalking()
        {
            if (velocityVector.magnitude > 0)
            {
                animator.SetBool("IsWalking", true);
                if ((Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || 
                    (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)))
                {
                    animator.SetBool("Up", true);
                }
                else
                {
                    animator.SetBool("Up", false);
                }

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    animator.SetBool("Left", true);
                }
                else
                {
                    animator.SetBool("Left", false);
                }

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    animator.SetBool("Right", true);
                }
                else
                {
                    animator.SetBool("Right", false);
                }

                if ((Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) ||
                    (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)))
                {
                    animator.SetBool("Down", true);
                }
                else
                {
                    animator.SetBool("Down", false);
                }
                return true;
            }
            else
            {
                animator.SetBool("IsWalking", false);
                // reset the walking sound effects when not moving
                GetComponent<StudioEventEmitter>().EventInstance.setParameterByName("DirtWalk", 0.0f);
                GetComponent<StudioEventEmitter>().EventInstance.setParameterByName("GravelWalk", 0.0f);
                GetComponent<StudioEventEmitter>().EventInstance.setParameterByName("WoodZone", 0.0f);
                return false;
            }
        }

    }

}
