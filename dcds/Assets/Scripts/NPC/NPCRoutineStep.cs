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
        NPCRoutineStep m_nextStep;

        [SerializeField]
        Vector3 m_targetLocation;
        [SerializeField]
        AnimationClip m_animationOnRest;

        [Header("Transition Variables")]
        [SerializeField]
        float m_movementSpeedToNextStep = 5f;
        [SerializeField]
        RoutineCondition transitionCondition;

        bool m_transitioningToNextStep;

        public NPCRoutineStep NextStep { get => m_nextStep; set => m_nextStep = value; }
        public Vector3 TargetLocation { get => m_targetLocation; set => m_targetLocation = value; }
        public float MovementSpeedToNextStep { get => m_movementSpeedToNextStep; set => m_movementSpeedToNextStep = value; }
        internal RoutineCondition TransitionCondition { get => transitionCondition; set => transitionCondition = value; }
        public bool TransitioningToNextStep { get => m_transitioningToNextStep; set => m_transitioningToNextStep = value; }

        public NPCRoutineStep()
        {
            m_targetLocation = TownManager.Instance.Player.transform.position;
            m_movementSpeedToNextStep = 5f;
            m_nextStep = null;
        }

        public NPCRoutineStep(Vector3 target, float moveSpeed, NPCRoutineStep next)
        {
            m_targetLocation = target;
            m_movementSpeedToNextStep = moveSpeed;
            m_nextStep = next;
        }

    }
}
