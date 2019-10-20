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

        bool inRange = false;
        bool interacted = false;
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
            if (other.gameObject.GetComponent<Interact>())
            {
                if (inRange == false)
                {
                    Debug.Log("You can interact with me.");

                    inRange = true;
                }

            }
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.gameObject.GetComponent<Interact>())
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

}
