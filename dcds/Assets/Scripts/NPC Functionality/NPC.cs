using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class NPC:MonoBehaviour
    {
        [SerializeField]
        string m_name = "";

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

        [ReadOnly]
        bool m_followPlayer = false;

        [SerializeField]
        //Personal Space bubble; how far the NPC will stop from the target when following the player.
        float m_stoppingDistance = 3f;

        //Transform that NPC has to follow
        private Transform transformToFollow;
        //NavMesh Agent variable
        NavMeshAgent followAgent;
        #endregion

        #region Getters/Setters
        /// <summary>
        /// Bool set to true if the NPC is currently following the TransformToFollow
        /// </summary>
        public bool IsFollowing { get => m_followPlayer; set => m_followPlayer = value; }

        /// <summary>
        /// Current NPC Move Speed
        /// </summary>
        public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }

        /// <summary>
        /// NavMeshAgent responsible for path finding and following
        /// </summary>
        public NavMeshAgent FollowAgent { get => followAgent; set => followAgent = value; }

        public string Name { get => m_name; set => m_name = value; }

        /// <summary>
        /// The game object the NPC is currently following
        /// </summary>
        public Transform TransformToFollow { get => transformToFollow; set => transformToFollow = value; }

        /// <summary>
        /// NPC's current Stance toward the player
        /// </summary>
        public int Stance { get => stance; set => stance = value; }

        /// <summary>
        /// NPC's current Mood indicator
        /// </summary>
        public Mood CurrentMood { get => currentMood; set => currentMood = value; }


        #endregion

        #region Routine Variables

        public List<NPCRoutineStep> routineSteps;

        [SerializeField]
        private bool m_routinePaused;

        [ReadOnly]
        private NPCRoutineStep m_currentStep;

        [ReadOnly]
        private bool m_transitioningToNextStep;


        #endregion

        void Start()
        {
            followAgent = GetComponent<NavMeshAgent>();
            followAgent.speed = movementSpeed;
            followAgent.isStopped = false;
            m_currentStep = routineSteps[0];
            SetUpRoutine();

        }

        // Update is called once per frame
        void Update()
        {
            if (m_followPlayer)
            {
                //Follow the player
                followAgent.destination = transformToFollow.position;
            }
            else if (!m_routinePaused && routineSteps.Count != 0)
            {
                //If we were transitioning to the next step and we've arrived, update current step.
                if (m_transitioningToNextStep
                    && !followAgent.pathPending
                    && followAgent.remainingDistance <= followAgent.stoppingDistance
                    && (!followAgent.hasPath || followAgent.velocity.sqrMagnitude == 0f))
                {
                    BeginIdleInRoutine();
                }
                //If we aren't transitioning, check to see if we need to transition.
                else
                {
                    if (m_currentStep == null)
                    {
                        m_currentStep = routineSteps[0];
                    }
                    m_currentStep.CheckCondition();
                }
            }

        }

        public void Move()
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);

            gameObject.transform.position += movement * movementSpeed * Time.deltaTime;
        }


        #region Routine Functions
        /// <summary>
        /// Sets up a routine when game starts
        /// </summary>
        public void SetUpRoutine()
        {
            for (int i = 1; i < routineSteps.Count; i++)
            {
                routineSteps[i - 1].NextStep = routineSteps[i];
            }
            routineSteps[routineSteps.Count - 1].NextStep = routineSteps[0];
            m_currentStep = FindCurrentStep();
            //Make sure the NPC is poised at its first routine step on play
            gameObject.transform.position = m_currentStep.TargetLocation;
            m_currentStep.ResetCondition();
        }

        /// <summary>
        /// Called after routine is unpaused to allow the NPC to return to their correct step.
        /// </summary>
        /// <returns>The routine step at which an NPC should return to; returns the last routine step if the current step cannot be determined.</returns>
        public NPCRoutineStep FindCurrentStep()
        {
            foreach (NPCRoutineStep step in routineSteps)
            {
                if (step.TargetTimePoints >= TownManager.Instance.CurrentTimePoints)
                {
                    return step;
                }
            }
            return routineSteps[routineSteps.Count - 1];
        }

        /// <summary>
        /// Called whenever TimePoints are updated
        /// </summary>
        public void UpdateTransitionCondition()
        {
            m_currentStep.CurrentTimePoints = TownManager.Instance.CurrentTimePoints;
            if (m_currentStep.CheckCondition() && !m_transitioningToNextStep)
            {
                SetUpNavMesh(true, m_currentStep.NextStep.TargetLocation, 0f);
                followAgent.isStopped = false;
                //Debug.Log("The next transition should occur.");
            }
        }

        /// <summary>
        /// Sets up the NPC nav mesh's target location. Does NOT resume following; call separately after calling this 'followAgent.isStopped = false;'
        /// </summary>
        /// <param name="transitioning">True if transitioning to next routine step, false otherwise.</param>
        /// <param name="targetLocation"></param>
        /// <param name="stoppingDistance">How far the nav mesh should stop from the target location</param>
        private void SetUpNavMesh(bool transitioning, Vector3 targetLocation, float stoppingDistance)
        {
            m_transitioningToNextStep = transitioning;
            followAgent.destination = targetLocation;
            followAgent.stoppingDistance = stoppingDistance;
        }

        /// <summary>
        /// Any things that need to be set in the NPC when they arrive at their routine target destination should be added here.
        /// </summary>
        private void BeginIdleInRoutine()
        {
            m_transitioningToNextStep = false;
            //Debug.Log("Arrived at target for " + m_currentStep.TargetTimePoints + ".");
            m_currentStep.ResetCondition();
            m_currentStep = m_currentStep.NextStep;
            //Debug.Log("Idling until timepoints = " + m_currentStep.TargetTimePoints);


        }

        #endregion

        /// <summary>
        /// Toggles whether or not the NPC is following the player; pauses routine if they are.
        /// </summary>
        public void ToggleFollowPlayer()
        {
            m_followPlayer = !m_followPlayer;
            if (m_followPlayer)
            {
                m_routinePaused = true;
            }
            else
            {
                m_routinePaused = false;
            }
        }

        #region Relationship Functions
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
        #endregion
    }
}
