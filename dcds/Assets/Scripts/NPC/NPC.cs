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
        // Enum for NPC's stance
        public enum Mood { Good, Neutral, Bad };

        // -20 to 20 point scale 
        public int stance;
        // var for this NPC's mood
        public Mood currentMood;

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

        public string Name { get => name; set => name = value; }
        public bool IsFollowingRoutine { get => isFollowingRoutine; set => isFollowingRoutine = value; }
        public Transform TransformToFollow { get => transformToFollow; set => transformToFollow = value; }

        public int Stance { get => stance; set => stance = value; }
        public Mood CurrentMood { get => currentMood; set => currentMood = value; }


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

        // Helper function for rolling the Mood Of The Day modifier if it hasn't been rolled for today yet
        public void MoodOfTheDay()
        {
            float rng = UnityEngine.Random.value;

            if(rng < 0.2)
            {
                currentMood = Mood.Bad;
            } else if( rng < 0.8)
            {
                currentMood = Mood.Neutral;
            } else
            {
                currentMood = Mood.Good;
            }
        }

        // Helper function for calculating stance change based on player actions
        public void StanceChange(int ammt)
        {
            stance += ammt; // change stance by passed ammount
            stance = Mathf.Max(stance, -20); // stance can't be less than -20
            stance = Mathf.Min(stance, 20); // stance can't be greater than 20
        }

        // Helper function for changing a character's mood (false means go down, true means go up)
        public void MoodChange(bool positiveChange)
        {
            if (positiveChange)
            {
                switch (currentMood)
                {
                    case Mood.Bad:
                        currentMood = Mood.Neutral;
                        break;
                    case Mood.Neutral:
                        currentMood = Mood.Good;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (currentMood)
                {
                    case Mood.Good:
                        currentMood = Mood.Neutral;
                        break;
                    case Mood.Neutral:
                        currentMood = Mood.Bad;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
