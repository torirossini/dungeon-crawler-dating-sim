using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class NPCRoutineStep
    {
        NPCRoutineStep nextStep;

        [SerializeField]
        Vector3 targetLocation;
        [SerializeField]
        AnimationClip animationOnRest;

        [Header("Transition Variables")]
        [SerializeField]
        float movementSpeedToNextStep = 5f;
        [SerializeField]
        RoutineCondition transitionCondition;

        public NPCRoutineStep NextStep { get => nextStep; set => nextStep = value; }
        public Vector3 TargetLocation { get => targetLocation; set => targetLocation = value; }
        public float MovementSpeedToNextStep { get => movementSpeedToNextStep; set => movementSpeedToNextStep = value; }
        internal RoutineCondition TransitionCondition { get => transitionCondition; set => transitionCondition = value; }

        public NPCRoutineStep(Vector3 target, float moveSpeed, NPCRoutineStep next)
        {
            targetLocation = target;
            movementSpeedToNextStep = moveSpeed;
            nextStep = next;
        }

    }
}
