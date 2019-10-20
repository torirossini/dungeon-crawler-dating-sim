using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
namespace Assets
{
    //variables
    [SerializeField]
    float pSpeed = 0.15f;
    bool inRange = false;
    bool interacted = false;
    float moveHorizontal;
    float moveVertical;
    Vector3 playerLoc;

    private Combatant combatScript;


        public float PlayerSpeed
        {
            get { return playerSpeed; }
        }

    // Start is called before the first frame update
    void Start()
    {
        //  These aren't necessarry afaik
        //  moveHorizontal = Input.GetAxis("Horizontal");
        //  moveVertical = Input.GetAxis("Vertical");
        combatScript = GetComponent<Combatant>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  If player is in combat, use combat movement methods instead
        if(!combatScript.IsInCombat) 
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
            pMove(pSpeed);
        }
    }

    //moveMethod
    public void pMove(float speed)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if(Input.GetKey(KeyCode.LeftShift) == true)
        {
            speed += speed * .6f;
            gameObject.transform.position += movement * speed * Time.deltaTime;
            playerLoc = gameObject.transform.position;
        }
        else
        {
            gameObject.transform.position += movement * speed * Time.deltaTime;
            playerLoc = gameObject.transform.position;
        }
    }
    

    //###################################################### Interaction Stuff
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Interact>())
        {
            if (other.gameObject.GetComponent<Interact>())
            {
                if (inRange == false)
                {
                    Debug.Log("You can interact with me.");

                    inRange = true;
                }

            }

        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Interact>())
        {
            if (interacted == false)
            {
                if (interacted == false)
                {
                    if (Input.GetKey(KeyCode.E) == true)
                    {
                        Debug.Log("You have interacted with me.");
                        interacted = true;
                    }
                }

                if (Input.GetKey(KeyCode.E) == false)
                {
                    interacted = false;
                }



            }
        }

        //
        public void OnTriggerExit(Collider other)
        {
            inRange = false;
            interacted = false;
        }
    }


    public Vector3 PlayerLoc
    {
        get { return playerLoc; }

    }

    public float PSpeed
    {
        get { return pSpeed; }
    }
}
*/