using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Utility;

namespace Assets.Scripts
{
    [Serializable]
    public class RoutineCondition
    {
        [SerializeField]
        Condition conditionToTransition;
        [SerializeField]
        float conditionThreshold;

        float currentProgress;

        bool conditionMet;

        public float ConditionThreshold { get => conditionThreshold; }
        public Condition ConditionToTransition { get => conditionToTransition; set => conditionToTransition = value; }
        public float CurrentProgress { get => currentProgress; set => currentProgress = value; }
        public bool ConditionMet { get => conditionMet; set => conditionMet = value; }

        public RoutineCondition()
        {
            conditionMet = false;
        }
        /// <summary>
        /// Called in update in NPCRoutine
        /// </summary>
        /// <returns>True if transition condition is met, false otherwise</returns>
        public bool CheckCondition()
        {
            if (currentProgress >= conditionThreshold)
            {
                conditionMet = true;
            }
            return conditionMet;
        }
        





    }
}
