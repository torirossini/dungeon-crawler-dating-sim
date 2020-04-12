using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {

        //variables
        [SerializeField]
        float playerSpeed = 0.15f;

        [SerializeField]
        float jumpForce = 10f;

        float xMovement;
        float yMovement;

        private Rigidbody2D rb;
        private Vector2 velocityVector;

        private Animator animator;
        private Sprite playerSprite;



        public float PlayerSpeed
        {
            get { return playerSpeed; }
        }

        float isGroundedRayLength = .1f;
        LayerMask layerMaskForGrounded = 9;
        public bool isGrounded
        {
            get
            {
                Vector3 position = transform.position;
                position.y = GetComponent<Collider2D>().bounds.min.y + 0.1f;
                float length = isGroundedRayLength + 0.1f;
                Debug.DrawRay(position, Vector3.down * length);
                bool grounded = Physics2D.Raycast(position, Vector3.down, length, layerMaskForGrounded.value);
                return grounded;
            }
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            playerSprite = GetComponent<SpriteRenderer>().sprite;
            velocityVector = Vector2.zero;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            

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
            if(rb)
            {
                xMovement = Input.GetAxis("Horizontal");
                yMovement = Input.GetAxis("Vertical");
                Vector2 velocity = rb.velocity;
                float xForce = xMovement * playerSpeed * Time.deltaTime;
                velocity.x = xForce;

                if (Input.GetButtonDown("Vertical") && isGrounded)
                { 
                    velocity.y = jumpForce;
                }

                rb.velocity = velocity;
            }

        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<InteractionObject>())
            {
                InteractionObject interactable = other.gameObject.GetComponent<InteractionObject>();
                interactable.SetAblilityToInteract(true);
            }        }

        public void OnTriggerStay2D(Collider2D other)
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

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<InteractionObject>())
            {
                InteractionObject interactable = other.gameObject.GetComponent<InteractionObject>();
                interactable.SetAblilityToInteract(false);
            }
        }

        private bool IsWalking()
        {
            if (rb.velocity.magnitude > 0)
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
