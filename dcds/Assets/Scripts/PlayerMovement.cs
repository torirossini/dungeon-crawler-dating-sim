using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables
    [SerializeField]
    float pSpeed = 0.15f;

    float moveHorizontal;
    float moveVertical;


    public float PlayerSpeed
    {
        get { return pSpeed; }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = Vector3.zero;
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        pMove(pSpeed);
    }

    //moveMethod
    public void pMove(float speed)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        gameObject.transform.position += movement * speed * Time.deltaTime;

    }

}
