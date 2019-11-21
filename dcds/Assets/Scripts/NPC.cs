using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    class NPC:MonoBehaviour
    {
        float movementSpeed = 5f;

        //Transform that NPC has to follow
        public Transform transformToFollow;
        //NavMesh Agent variable
        NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            //Follow the player
            agent.destination = transformToFollow.position;
        }

        public void Move()
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);

            gameObject.transform.position += movement * movementSpeed * Time.deltaTime;
        }
    }
}
