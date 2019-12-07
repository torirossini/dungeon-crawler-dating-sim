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
        private float distanceToPlayer;
        [SerializeField]
        private float timeElapsed;

        float conditionThreshold;

        public float ConditionThreshold { get => conditionThreshold; }
        public Condition ConditionToTransition { get => conditionToTransition; set => conditionToTransition = value; }

        public RoutineCondition()
        {
            if (conditionToTransition == Condition.DistanceFromPlayer)
            {
                conditionThreshold = distanceToPlayer;
            }
            else if (conditionToTransition == Condition.TimeElapsed)
            {
                conditionThreshold = timeElapsed;
            }
        }



    }
}
