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
    /*
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

        yield return new WaitUntil(() => currentStep.TransitionCondition.ConditionMet);

        Debug.Log("Arrived! Now waiting for transition condition.");
        transitioning = false;

        if (currentStep.TransitionCondition.ConditionToTransition == Condition.TimeElapsed)
        {
            yield return new WaitForSeconds(currentStep.TransitionCondition.ConditionThreshold);
        }

        TransitionToNextStep();


    }

    /// <summary>
    /// Updates CurrentProgress in RoutineCondition of currentStep
    /// </summary>
    private void UpdateRoutineState()
    {
        if (currentStep.TransitionCondition.ConditionToTransition == Condition.DistanceFromFollowTarget)
        {
            currentStep.TransitionCondition.CurrentProgress = Vector3.Distance(myNPC.gameObject.transform.position, myNPC.TransformToFollow.position);
        }
        else if (currentStep.TransitionCondition.ConditionToTransition == Condition.TimeElapsed)
        {
            currentStep.TransitionCondition.CurrentProgress = currentStep.TransitionCondition.CurrentProgress + Time.deltaTime;
        }
        else if (currentStep.TransitionCondition.ConditionToTransition == Condition.CurrentTimePoints)
        {
            currentStep.TransitionCondition.CurrentProgress = TownManager.Instance.TimePoints;
        }
    }
    */
}


