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
        bool followPlayer = true;

        //Transform that NPC has to follow
        public Transform transformToFollow;
        //NavMesh Agent variable
        NavMeshAgent followAgent;

        public bool FollowPlayer { get => followPlayer; set => followPlayer = value; }
        public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        public NavMeshAgent FollowAgent { get => followAgent; set => followAgent = value; }

        void Start()
        {
            followAgent = GetComponent<NavMeshAgent>();
            followAgent.speed = movementSpeed;

        }

        // Update is called once per frame
        void Update()
        {
            if (followPlayer)
            {
                //Follow the player
                followAgent.destination = transformToFollow.position;
            }

        }

        public void Move()
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);

            gameObject.transform.position += movement * movementSpeed * Time.deltaTime;
        }
        public void ToggleFollowPlayer()
        {
            followPlayer = !followPlayer;
        }

    }
}
