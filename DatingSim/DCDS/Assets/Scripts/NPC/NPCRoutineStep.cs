﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Utility;

namespace Assets.Scripts
{
    [Serializable]
    public class NPCRoutineStep
    {
        NPCRoutineStep m_nextStep;
        [SerializeField]
        string m_routineStepName = "";
        [SerializeField]
        Vector3 m_targetLocation;
        [SerializeField]
        AnimationClip m_animationOnRest;

        [Header("Transition Variables")]
        [SerializeField]
        Condition m_conditionToTransition;
        [SerializeField]
        int m_targetTimePoints;

        int m_currentTimePoints;

        bool m_conditionMet = false;

        bool m_transitioningToNextStep;

        #region Getters/Setters
        public NPCRoutineStep NextStep { get => m_nextStep; set => m_nextStep = value; }
        public Vector3 TargetLocation { get => m_targetLocation; set => m_targetLocation = value; }
        public bool TransitioningToNextStep { get => m_transitioningToNextStep; set => m_transitioningToNextStep = value; }
        public bool ConditionMet { get => m_conditionMet; set => m_conditionMet = value; }
        public int CurrentTimePoints { get => m_currentTimePoints; set => m_currentTimePoints = value; }
        public Condition ConditionToTransition { get => m_conditionToTransition; set => m_conditionToTransition = value; }
        public int TargetTimePoints { get => m_targetTimePoints; set => m_targetTimePoints = value; }

        #endregion

        public NPCRoutineStep()
        {
            m_targetLocation = Vector3.zero;
            m_nextStep = null;
            m_currentTimePoints = 0;
            m_conditionToTransition = Condition.CurrentTimePoints;
        }

        public NPCRoutineStep(Vector3 target, NPCRoutineStep next, Condition condition)
        {
            m_targetLocation = target;
            m_nextStep = next;
            m_currentTimePoints = 0;
            m_conditionToTransition = condition;


        }

        /// <summary>
        /// Resets transition conditions once the current step transitions to the next step
        /// </summary>
        public void ResetCondition()
        {
            m_currentTimePoints = 0;
            m_conditionMet = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>True if transition condition is met, false otherwise</returns>
        public bool CheckCondition()
        {
            if (m_currentTimePoints == m_targetTimePoints && m_conditionMet == false)
            {
                m_conditionMet = true;
            }
            return m_conditionMet;
        }



    }
}
