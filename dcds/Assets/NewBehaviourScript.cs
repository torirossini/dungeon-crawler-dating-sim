using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //variables

    float pSpeed = 0.15f;
    Rigidbody playerObject;
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    
   



    // Start is called before the first frame update
    void Start()
    {
        playerObject.position = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
       pMove(playerObject.position, pSpeed);
    }


    //moveMethod
    public void pMove(float speed)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (Input.GetKey(KeyCode.W))
        {
            playerObject.position += (0.0f, 0.0f, speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveVertical -= (0.0f, 0.0f, speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal -= (speed, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal += (speed, 0.0f, 0.0f);
        }

        
        
    }

    
}
