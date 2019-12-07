using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Utility;

namespace Assets.Scripts
{
    [Serializable]
    public class NPCRoutine
    {
        private NPC myNPC;
        private GameObject npcObject;

        public List<NPCRoutineStep> routineSteps;

        [SerializeField]
        float defaultMoveSpeed = 5f;
        NPCRoutineStep currentStep;

        [SerializeField]
        bool loopRoutine = true;

        [SerializeField]
        bool paused = false;

        [SerializeField]
        bool stopped = false;

        bool transitioning;
        public NPCRoutineStep CurrentStep { get => currentStep; set => currentStep = value; }
        public bool Transitioning { get => transitioning; set => transitioning = value; }

        public NPCRoutine(GameObject npc, NPCRoutineStep firstStep)
        {
            myNPC = npc.GetComponent<NPC>();
            npcObject = npc;
            defaultMoveSpeed = myNPC.MovementSpeed;
            routineSteps[0] = firstStep;
        }
        public bool TogglePauseRoutine()
        {
            paused = !paused;
            if(paused)
            {
                myNPC.FollowAgent.destination = myNPC.GetComponent<GameObject>().transform.position;
            }
            else
            {
                myNPC.FollowAgent.destination = currentStep.TargetLocation;
            }
            return paused;
        }
        public void RestartRoutine()
        {
            paused = true;
            currentStep = routineSteps[0];
            stopped = false;
            paused = false;
            transitioning = false;
        }

        public NPCRoutineStep TransitionToNextStep()
        {
            if (currentStep.NextStep!=null)
            {
                currentStep = currentStep.NextStep;
            }
            else
            {
                stopped = true;
                if(loopRoutine)
                {
                    RestartRoutine();
                }
            }
            return currentStep.NextStep;
        }

        public IEnumerator FollowRoutineStep()
        {
            Debug.Log("Moving to next step");
            myNPC.FollowAgent.destination = currentStep.TargetLocation;
            transitioning = true;

            yield return new WaitUntil(() => !myNPC.FollowAgent.pathPending
            && (myNPC.FollowAgent.remainingDistance <= myNPC.FollowAgent.stoppingDistance)
            && (!myNPC.FollowAgent.hasPath || myNPC.FollowAgent.velocity.sqrMagnitude == 0f));

            Debug.Log("Arrived! Now waiting for transition condition.");
            transitioning = false;

            if (currentStep.TransitionCondition.ConditionToTransition == Condition.TimeElapsed)
            {
                yield return new WaitForSeconds(currentStep.TransitionCondition.ConditionThreshold);
            }

            TransitionToNextStep();


        }

        

    }
}
