using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : Singleton<Player>
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

        [Header("Interact Vars")]
        [SerializeField]
        float delayBeforeAllowInteract = .5f;
        bool canInteract;



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
            canInteract = true;
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
                    GetComponent<FMODCustomEvent>().SetEventParam("event:/Sound Effects/Jumping", "JumpEffects", 0);
                    GetComponent<FMODCustomEvent>().PlayEvent("event:/Sound Effects/Jumping");
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
            }
            // check for collision with ground zones and handle accordingly
            if(other.gameObject.CompareTag("DirtZone") || other.gameObject.CompareTag("GravelZone") || other.gameObject.CompareTag("WoodZone"))
            {
                // play the landing sound effect
                GetComponent<FMODCustomEvent>().SetEventParam("event:/Sound Effects/Jumping", "JumpEffects", 1);
                GetComponent<FMODCustomEvent>().PlayEvent("event:/Sound Effects/Jumping");
                // set the WalkingSurfaces parameter of the walking event based on which surface is being collided with
                if (other.gameObject.CompareTag("DirtZone"))
                {
                    GetComponent<FMODCustomEvent>().SetEventParam("event:/Sound Effects/Walking", "WalkingSurfaces", 0);
                }
                else if (other.gameObject.CompareTag("GravelZone"))
                {
                    GetComponent<FMODCustomEvent>().SetEventParam("event:/Sound Effects/Walking", "WalkingSurfaces", 1);
                }
                else if (other.gameObject.CompareTag("WoodZone"))
                {
                    GetComponent<FMODCustomEvent>().SetEventParam("event:/Sound Effects/Walking", "WalkingSurfaces", 2);
                }
                // start playing the parameterized walking event
                GetComponent<FMODCustomEvent>().PlayEvent("event:/Sound Effects/Walking");
                GetComponent<FMODCustomEvent>().PauseEvent("event:/Sound Effects/Walking", false);
            }
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<InteractionObject>())
            {
                InteractionObject interactable = other.gameObject.GetComponent<InteractionObject>();
                
                if (Input.GetKey(KeyCode.E) && !interactable.Interacted)
                {
                    Interact(interactable);
                }
            }
            // unpause the walking sound if it was paused
            if (other.gameObject.CompareTag("DirtZone") || other.gameObject.CompareTag("GravelZone") || other.gameObject.CompareTag("WoodZone"))
            {
                GetComponent<FMODCustomEvent>().PauseEvent("event:/Sound Effects/Walking", false);
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<InteractionObject>())
            {
                InteractionObject interactable = other.gameObject.GetComponent<InteractionObject>();
                interactable.SetAblilityToInteract(false);
            }
            // pause the walking sound if not on the ground
            if (other.gameObject.CompareTag("DirtZone") || other.gameObject.CompareTag("GravelZone") || other.gameObject.CompareTag("WoodZone"))
            {
                GetComponent<FMODCustomEvent>().PauseEvent("event:/Sound Effects/Walking", true);
            }
        }

        /// <summary>
        /// Private method used to handle what happens to the player once they interact with something
        /// </summary>
        /// <param name="interactable"></param>
        /// <returns></returns>
        private bool Interact(InteractionObject interactable)
        {
            if (canInteract)
            {
                interactable.Interact();
                interactable.DoPulse();
                StartCoroutine(TriggerInteractDelay());
                return true;
            }
            return false;
        }

        /// <summary>
        /// Resets the can interact boolean once delay ends
        /// </summary>
        /// <returns></returns>
        private IEnumerator TriggerInteractDelay()
        {
            canInteract = false;
            yield return new WaitForSeconds(delayBeforeAllowInteract);
            canInteract = true;
        }


        #region Teleport Methods

        /// <summary>
        /// Teleports the player to destination Vector2
        /// </summary>
        /// <param name="destination"></param>
        public void TeleportTo(Vector2 destination)
        {
            gameObject.transform.position = destination;
        }
        /// <summary>
        /// Teleports the player to destination game object
        /// </summary>
        /// <param name="destination"></param>
        public void TeleportTo(GameObject destination)
        {
            gameObject.transform.position = destination.transform.position;
        }
        #endregion

        /// <summary>
        /// Handles animator changes
        /// </summary>
        /// <returns></returns>
        private bool IsWalking()
        {
            if (rb.velocity.magnitude > 0)
            {
                animator.SetBool("IsWalking", true);
                // handle which animation to draw onscreen
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
                // pause the walking sound effect
                GetComponent<FMODCustomEvent>().PauseEvent("event:/Sound Effects/Walking", true);
                return false;
            }
        }

    }

}
