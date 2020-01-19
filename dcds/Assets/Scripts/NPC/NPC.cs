using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class NPC:MonoBehaviour
    {
        [SerializeField]
        string name;

        #region Relationship Variables
        float stance;
        int mood;

        bool romanceable;
        #endregion

        #region Movement and Pathing
        [SerializeField]
        float movementSpeed = 5f;

        [SerializeField]
        bool followPlayer = true;

        //Transform that NPC has to follow
        private Transform transformToFollow;
        //NavMesh Agent variable
        NavMeshAgent followAgent;
        #endregion

        #region Routine
        [SerializeField]
        NPCRoutine routine;
        bool isFollowingRoutine;
        #endregion

        public bool FollowPlayer { get => followPlayer; set => followPlayer = value; }
        public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        public NavMeshAgent FollowAgent { get => followAgent; set => followAgent = value; }

        public float Stance { get => stance; set => stance = value; }
        public int Mood { get => mood; set => mood = value; }
        public string Name { get => name; set => name = value; }
        public bool IsFollowingRoutine { get => isFollowingRoutine; set => isFollowingRoutine = value; }
        public Transform TransformToFollow { get => transformToFollow; set => transformToFollow = value; }

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
            if(followPlayer)
            {
                isFollowingRoutine = false;
            }
        }

    }
}
