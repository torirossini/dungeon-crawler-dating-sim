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
        Condition conditionToTransition = Condition.CurrentTimePoints;
        [SerializeField]
        float conditionThreshold;

        float currentProgress;

        bool conditionMet;

        /// <summary>
        /// Condition number to meet to say that this condition has been met. Currently only supports current TimePoints
        /// </summary>
        public float ConditionThreshold { get => conditionThreshold; }

        /// <summary>
        /// Only Current Time Point support right now. 
        /// </summary>
        public Condition ConditionToTransition { get => conditionToTransition; set => conditionToTransition = value; }

        public float CurrentProgress { get => currentProgress; set => currentProgress = value; }
        public bool ConditionMet { get => conditionMet; set => conditionMet = value; }

        public RoutineCondition()
        {
            conditionMet = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>True if transition condition is met, false otherwise</returns>
        public bool CheckCondition()
        {
            if (currentProgress >= conditionThreshold && conditionMet == false)
            {
                conditionMet = true;
            }
            return conditionMet;
        }
        





    }
}
