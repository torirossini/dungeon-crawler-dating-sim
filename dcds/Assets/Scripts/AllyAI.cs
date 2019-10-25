using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts
{
    class AllyAI : MonoBehaviour
    {
        Vector3 playerLoc;
        Vector3 allyLoc;
        public GameObject playerObj;
        float distX;
        float distZ;
        float allySpd;
        bool combatActive = false;
        Vector3 goalLoc;
        
        void Awake()
        {
            
        }

        void Update()
        {
            playerLoc = playerObj.transform.position;
            allyLoc = gameObject.transform.position;
            
            //offsets the location of the player object to prevent floor clipping and looking at an angle
            goalLoc = playerObj.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
           
            transform.LookAt(goalLoc);
            allySpd = playerObj.GetComponent<Player>().PlayerSpeed;
           
            followPlayer();
           // gameObject.transform.position += transform.forward * allySpd * Time.deltaTime;
        }

        // follows player
        public void followPlayer()
        {
            distX = playerLoc.x - allyLoc.x;
            distZ = playerLoc.z - allyLoc.z;
            if (combatActive == false)
            {
                if (distX < -2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, goalLoc, allySpd * Time.deltaTime);
                    Debug.Log("You have moved away!");
                }

                if (distX > 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, goalLoc, allySpd * Time.deltaTime);
                    Debug.Log("You have moved away!");
                }

                if (distZ > 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, goalLoc, allySpd * Time.deltaTime);
                    Debug.Log("You have moved away!");
                }

                if (distZ < -2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, goalLoc, allySpd * Time.deltaTime);
                    Debug.Log("You have moved away!");
                }
            }
        }
    }
}
